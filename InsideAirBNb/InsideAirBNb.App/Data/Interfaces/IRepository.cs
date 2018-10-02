using System;
using System.Collections.Generic;

namespace InsideAirBNB.App.Data.Interfaces
{
    public interface IRepository<T>
    {
        int Count();
        int Count(Func<T, bool> predicate);
        void Create(T entity);
        void Delete(T entity);
        List<T> Find(Func<T, bool> predicate);
        List<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }
}
