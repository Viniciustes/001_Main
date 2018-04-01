using CTJEvaluation001.Domain.Entities;

namespace CTJEvaluation001.Domain.Interfaces.Repositories
{
    public interface IObserverRepository
    {
        Observer GetByChapa(string chapa);
    }
}
