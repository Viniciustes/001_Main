using CTJEvaluation001.Domain.Entities;

namespace CTJEvaluation001.Domain.Interfaces.Repositories
{
    public interface IObservedRepository
    {
        Observed GetByChapa(string chapa);
    }
}
