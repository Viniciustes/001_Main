using System.Collections.Generic;

namespace CTJEvaluation001.Application
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Dispose();
    }
}
