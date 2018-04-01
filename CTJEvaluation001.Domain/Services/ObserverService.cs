using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Repositories;
using CTJEvaluation001.Domain.Interfaces.Services;

namespace CTJEvaluation001.Domain.Services
{
    public class ObserverService : IObserverService
    {
        private readonly IObserverRepository _observerRepository;

        public ObserverService(IObserverRepository observerRepository)
        {
            _observerRepository = observerRepository;
        }

        public Observer GetByChapa(string chapa)
        {
            return _observerRepository.GetByChapa(chapa);
        }
    }
}
