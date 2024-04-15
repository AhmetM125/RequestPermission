﻿using System.Linq.Expressions;

namespace RequestPermission.Api.DataLayer.Generic
{
    public interface IGenericRepository<T> : IUnitOfWork where T : class
    {
        T GetByFilter(Expression<Func<T, bool>> filter);
        T Get(int id);
        T GetFirstOrDefault();
        IEnumerable<T> GetAll();
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter);
        IQueryable<T> GetQueryable();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteAll();
        void MultipleAdd(IEnumerable<T> entities);
        void MultipleUpdate(IEnumerable<T> entities);
        void MultipleDelete(IEnumerable<T> entities);

        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task MultipleAddAsync(IEnumerable<T> entities);
         IEnumerable<T> GetWithRawSql(string query, params object[] parameters);
         IEnumerable<T> GetWithRawSql(string query);

    }
}
