using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitArc.Core.NewFolder
{
    //farklı yapılar kullanılacağı için T yapısı eklendi
    class RepositoryBase<Tentity, Tcontext> : IRepository<Tentity>
        where Tentity : class
        where Tcontext : DbContext
    {
        protected readonly Tcontext context;
        public RepositoryBase(Tcontext context)
        {
            this.context = context;
        }

        public void Add(Tentity entity)
        {
            context.Set<Tentity>().Add(entity);
            Save();
        }

        public void Delete(Tentity entity)
        {
            context.Set<Tentity>().Remove(entity);
            Save();
        }

        public IQueryable<Tentity> GetAll()
        {
            return context.Set<Tentity>();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(Tentity entity)
        {
            context.Set<Tentity>().Update(entity);
            Save();
        }
    }
}
