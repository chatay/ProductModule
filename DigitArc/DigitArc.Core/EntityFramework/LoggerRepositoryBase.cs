using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitArc.Core.EntityFramework
{
    public class LoggerRepositoryBase<Tentity> : IRepository<Tentity>
        where Tentity : class
    {
        private readonly IRepository<Tentity> _decorated;
        private readonly ILogger _logger;
        public LoggerRepositoryBase(IRepository<Tentity> decorated, ILogger _logger)
        {
            _decorated = decorated;
            this._logger = _logger;
        }
        private void Log(string msg, object args = null)
        {
            _logger.LogInformation(msg, args);

        }
        public void Add(Tentity entity)
        {
            Log("In decorator - Before Adding {0}", entity);
            _decorated.Add(entity);
            Log("In decorator - After Adding {0}", entity);
        }

        public void Delete(Tentity entity)
        {
            Log("In decorator - Before Deleting {0}", entity);
            _decorated.Delete(entity);
            Log("In decorator - After Deleting {0}", entity);
        }

        public IQueryable<Tentity> GetAll()
        {
            Log("In decorator - Before Getting Entities");
            var result = _decorated.GetAll();
            Log("In decorator - After Getting Entities");
            return result;

        }

        public Tentity GetById(int id)
        {
            Log("In decorator - Before Getting Entity {0}", id);
            var result = _decorated.GetById(id);
            Log("In decorator - After Getting Entity {0}", id);
            return result;

        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Tentity entity)
        {
            Log("In decorator - Before Updating {0}", entity);
            _decorated.Update(entity);
            Log("In decorator - After Updating {0}", entity);
        }
    }
}
