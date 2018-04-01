using CTJEvaluation001.Domain.Entities;

namespace CTJEvaluation001.Domain.Interfaces.Services
{
    public interface IObserverService
    {
        Observer GetByChapa(string chapa);
    }
}
