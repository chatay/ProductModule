using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitArc.Core.EntityFramework
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
