using CTJEvaluation001.Domain.Entities;

namespace CTJEvaluation001.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User Find(string codigo);
    }
}
