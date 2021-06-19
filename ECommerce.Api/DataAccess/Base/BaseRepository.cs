using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Api.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.DataAccess.Base
{
    public class BaseRepository<TModel, TEntity> : IBaseRepository<TModel, TEntity> where TModel : class where TEntity : class
    {
        private readonly IMapper _mapper;
        private readonly ECommerceContext _context;

        public BaseRepository(IMapper mapper, ECommerceContext baseDbContext) {
            _mapper = mapper;
            _context = baseDbContext;
        }

        public virtual IQueryable<TEntity> Get() {
            return _context.Set<TEntity>();
        }

        public virtual IList<TModel> GetAll() {
            var result = _context.Set<TEntity>().ToList();
            return _mapper.Map<IList<TModel>>(result);
        }
        public virtual async Task<IList<TModel>> GetAllAsync() {
            var result = await _context.Set<TEntity>().ToListAsync();
            return _mapper.Map<IList<TModel>>(result);
        }
        public virtual TModel GetById(object id) {
            var result = _context.Set<TEntity>().Find(id);
            return _mapper.Map<TModel>(result);
        }
        public virtual async Task<TModel> GetByIdAsync(object id) {
            var result = await _context.Set<TEntity>().FindAsync(id);
            return _mapper.Map<TModel>(result);
        }
        public virtual List<TModel> GetByKey(Func<TEntity, bool> predicate) {
            var result = _context.Set<TEntity>().Where(predicate).ToList();
            return _mapper.Map<List<TModel>>(result);
        }
        public virtual async Task<List<TModel>> GetByKeyAsync(Expression<Func<TEntity, bool>> predicate) {
            var result = await _context.Set<TEntity>().Where(predicate).ToListAsync();
            return _mapper.Map<List<TModel>>(result);
        }


        public virtual TModel Add(TModel modelToAdd) {
            var entityToAdd = _mapper.Map<TEntity>(modelToAdd);
            var result = _context.Add(entityToAdd);
            SaveChanges();
            return _mapper.Map<TModel>(result.Entity);
        }
        public virtual async Task<TModel> AddAsync(TModel modelToAdd) {
            var entityToAdd = _mapper.Map<TEntity>(modelToAdd);
            var result = await _context.AddAsync(entityToAdd);
            await SaveChangesAsync();
            return _mapper.Map<TModel>(result.Entity);

        }
        public virtual void AddRange(IList<TModel> modelsToAdd) {
            var entitiesToAdd = _mapper.Map<TEntity>(modelsToAdd);
            _context.AddRange(entitiesToAdd);
            SaveChanges();
        }
        public virtual async Task AddRangeAsync(IList<TModel> modelsToAdd) {
            var entitiesToAdd = _mapper.Map<List<TEntity>>(modelsToAdd);
            await _context.AddRangeAsync(entitiesToAdd);
            await SaveChangesAsync();
        }


        public virtual void Update(TModel modelToUpdate) {
            var entityToUpdate = _mapper.Map<TEntity>(modelToUpdate);
            _context.Update(entityToUpdate);
            SaveChanges();
        }
        public void UpdateRange(IList<TModel> modelsToUpdate) {
            var entitiesToUpdate = _mapper.Map<TEntity>(modelsToUpdate);
            _context.UpdateRange(entitiesToUpdate);
            SaveChanges();
        }
        public virtual void DeleteById(object id) {
            var entityToDelete = _context.Set<TEntity>().Find(id);
            _context.Remove(entityToDelete);
            SaveChanges();
        }

        public virtual async Task DeleteByIdAsync(object id) {
            var entityToDelete = await _context.Set<TEntity>().FindAsync(id);
            _context.Remove(entityToDelete);
            await SaveChangesAsync();
        }

        public virtual void Delete(TModel modelToDelete) {
            var entityToDelete = _mapper.Map<TEntity>(modelToDelete);
            _context.Remove(entityToDelete);
            SaveChanges();
        }
        public virtual void DeleteRange(IList<TModel> modelsToDelete) {
            var entitiesToDelete = _mapper.Map<List<TEntity>>(modelsToDelete);
            _context.RemoveRange(entitiesToDelete);
            SaveChanges();
        }


        public virtual bool Exist(Expression<Func<TEntity, bool>> predicate) {
            return _context.Set<TEntity>().Any(predicate);
        }
        public async Task<int> SaveChangesAsync() {
            return await _context.SaveChangesAsync();
        }
        public int SaveChanges() {
            return _context.SaveChanges();
        }

    }
}
