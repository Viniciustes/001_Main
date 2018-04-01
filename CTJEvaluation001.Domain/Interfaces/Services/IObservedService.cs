using CTJEvaluation001.Domain.Entities;

namespace CTJEvaluation001.Domain.Interfaces.Services
{
    public interface IObservedService
    {
        Observed GetByChapa(string chapa);
    }
}
