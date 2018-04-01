using CTJEvaluation001.Domain.Interfaces.Services;
using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Repositories;

namespace CTJEvaluation001.Domain.Services
{
    public class ObservedService : IObservedService
    {
        private readonly IObservedRepository _observedRepository;

        public ObservedService(IObservedRepository observedRepository)
        {
            _observedRepository = observedRepository;
        }
        public Observed GetByChapa(string chapa)
        {
            return _observedRepository.GetByChapa(chapa);
        }
    }
}
