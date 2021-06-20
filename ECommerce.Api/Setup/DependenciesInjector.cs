﻿using System;
using System.Linq;
using System.Reflection;
using ECommerce.Model.Base;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Api.Setup
{
    public static class DependenciesInjector
    {
        #region Methods
        public static void AddIInjectableDependencies(this IServiceCollection services, Type objectType) {
            var types = (from t in objectType.Assembly.GetTypes()
                         where t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract &&
                               t.GetTypeInfo().ImplementedInterfaces.Any(i => i == typeof(IInjectable))
                         select (t)).OrderBy(p => p.Name).ToList();

            foreach (var type in types) {
                int max = 0;
                Type interfaceType = null;

                foreach (var iInterface in type.GetInterfaces()) {
                    var totalInterfacesImplementService = iInterface.GetInterfaces().Length;
                    if (iInterface.GetInterfaces().Any(e => e == typeof(IInjectable))
                        && max < totalInterfacesImplementService) {
                        max = totalInterfacesImplementService;
                        interfaceType = iInterface;
                    }
                }

                if (interfaceType is not null)
                    services.AddTransient(interfaceType, type);
            }
        }
        #endregion
    }
}
