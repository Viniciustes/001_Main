using CTJEvaluation001.Domain.Interfaces.Repositories;
using CTJEvaluation001.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CTJEvaluation001.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected CTJEvaluation001Context Db = new CTJEvaluation001Context();

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
