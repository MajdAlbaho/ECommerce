using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerce.Api.DataAccess.Base
{
    public interface IBaseRepository<TModel, TEntity> where TModel : class where TEntity : class
    {
        #region Get
        IQueryable<TEntity> Get();
        TModel GetById(object id);
        Task<TModel> GetByIdAsync(object id);
        IList<TModel> GetAll();
        Task<IList<TModel>> GetAllAsync();
        List<TModel> GetByKey(Func<TEntity, bool> predicate);
        Task<List<TModel>> GetByKeyAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Add
        TModel Add(TModel modelToAdd);
        Task<TModel> AddAsync(TModel modelToAdd);
        void AddRange(IList<TModel> modelsToAdd);
        Task AddRangeAsync(IList<TModel> modelsToAdd);
        #endregion

        #region Update
        void Update(TModel modelToUpdate);
        void UpdateRange(IList<TModel> modelsToUpdate);
        #endregion

        #region Delete
        void DeleteById(object id);
        Task DeleteByIdAsync(object id);
        void Delete(TModel modelToDelete);
        void DeleteRange(IList<TModel> modelsToDelete);
        #endregion

        #region Global
        Task<int> SaveChangesAsync();
        bool Exist(Expression<Func<TEntity, bool>> predicate);
        #endregion
    }
}
