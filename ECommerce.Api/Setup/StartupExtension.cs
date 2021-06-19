using ECommerce.Api.DataAccess;
using ECommerce.Api.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Api.Setup
{
    public static class StartupExtension
    {
        #region Methods
        public static IServiceCollection AddAppDependencies(this IServiceCollection serviceCollection, IConfiguration configuration) {
            #region Data
            serviceCollection.AddDbContext<ECommerceContext>(options =>
                options.UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("LocalConnection")));

            serviceCollection.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;
                options.User.RequireUniqueEmail = false;
            }
                )
                .AddEntityFrameworkStores<ECommerceContext>()
                .AddDefaultTokenProviders();
            #endregion

            #region Repositories
            //serviceCollection.AddIInjectableDependencies(typeof(CategoriesRepository));
            //serviceCollection.AddTransient(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            #endregion

            return serviceCollection;
        }
        #endregion
    }
}
