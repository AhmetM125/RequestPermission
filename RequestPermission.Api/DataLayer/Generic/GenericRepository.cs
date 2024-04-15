
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using RequestPermission.Api.Infrastracture;
using System.Linq.Expressions;

namespace RequestPermission.Api.DataLayer.Generic
{
    public class GenericRepository<T> : RequestPermissionContext, IUnitOfWork, IGenericRepository<T> where T : class
    {
        private readonly RequestPermissionContext _requestPermissionContext;
        public GenericRepository(DbContextOptions<RequestPermissionContext> options, RequestPermissionContext permissionContext)
            : base(options)
        {
            _requestPermissionContext = permissionContext;
        }

        public void Add(T entity)
        {
            _requestPermissionContext.Add(entity);
        }
        public async Task AddAsync(T entity)
        {
            await _requestPermissionContext.AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _requestPermissionContext.Remove(entity);
        }
        public void DeleteAll()
        {
            _requestPermissionContext.RemoveRange(_requestPermissionContext.Set<T>());
        }
        public T Get(int id)
        {
            return _requestPermissionContext.Set<T>().FirstOrDefault();
        }
        public IEnumerable<T> GetAll()
        {
            return _requestPermissionContext.Set<T>().ToList();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _requestPermissionContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetAsync(int id)
        {
            return await _requestPermissionContext.Set<T>().FirstOrDefaultAsync();
        }
        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _requestPermissionContext.Set<T>().FirstOrDefault(filter);
        }

        public T GetFirstOrDefault()
        {
            return _requestPermissionContext.Set<T>().FirstOrDefault();
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter)
        {
            return _requestPermissionContext.Set<T>().Where(filter);
        }
        public IQueryable<T> GetQueryable()
        {
            return _requestPermissionContext.Set<T>();
        }
        public IEnumerable<T> GetWithRawSql(string query, params object[] parameters) 

        {
            return _requestPermissionContext.Set<T>().FromSqlRaw(query, parameters).ToList();
        }
        public IEnumerable<T> GetWithRawSql(string query)
        {
            return _requestPermissionContext.Set<T>().FromSqlRaw(query).AsEnumerable();
        }
        public void MultipleAdd(IEnumerable<T> entities)
        {
            _requestPermissionContext.AddRange(entities);
        }

        public async Task MultipleAddAsync(IEnumerable<T> entities)
        {
            await _requestPermissionContext.AddRangeAsync(entities);
        }

        public void MultipleDelete(IEnumerable<T> entities)
        {
            _requestPermissionContext.RemoveRange(entities);
        }
        public void MultipleUpdate(IEnumerable<T> entities)
        {
            _requestPermissionContext.UpdateRange(entities);
        }

        public void Save()
        {
            _requestPermissionContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _requestPermissionContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _requestPermissionContext.Update(entity);
        }
    }
}
