using CTJEvaluation001.Domain.Interfaces.Repositories;
using CTJEvaluation001.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private ISelfEvaluationRepository selfEvaluationRepository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public ServiceBase(ISelfEvaluationRepository selfEvaluationRepository)
        {
            this.selfEvaluationRepository = selfEvaluationRepository;
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
