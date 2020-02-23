using System.Collections.Generic;
using System.Linq;
using ECommerce.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;

        public Repository(Data.Contexts.DataContext dataContext)
        {
            _entities = dataContext.Set<T>();
        }

        public T Get(int id)
        {
            return _entities.Find(id);
        }

        public T Insert(T entity)
        {
            _entities.Add(entity);

            return entity;
        }

        public IEnumerable<T> List()
        {
            return _entities.ToList();
        }

        public void Purge(int id)
        {
            T entity = Get(id);

            _entities.Remove(entity);
        }

        public IQueryable<T> Query()
        {
            return _entities;
        }

        public T Update(T entity)
        {
            _entities.Update(entity);

            return entity;
        }
    }
}