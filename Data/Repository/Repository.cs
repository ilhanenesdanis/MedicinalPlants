﻿using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Context _context;
        private  readonly DbSet<T> _dbSet;
        public Repository(Context context)
        {
            _context= context;
            _dbSet= _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(List<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Any(expression);
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Count(expression);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> expression)
        {
           return _dbSet.Where(expression).AsNoTracking().AsQueryable();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id); 
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(List<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
