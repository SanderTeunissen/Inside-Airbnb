using InsideAirBNB.App.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsideAirBNB.App.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly InsideAirBNBContext _context;

        public Repository(InsideAirBNBContext context)
        {
            _context = context;
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        protected void Save() => _context.SaveChanges();
    }
}
