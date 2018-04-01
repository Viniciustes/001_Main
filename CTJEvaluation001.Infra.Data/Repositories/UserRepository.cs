using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Repositories;

namespace CTJEvaluation001.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public User Find(string codigo)
        {
            return Db.User.Find(codigo);
        }
    }
}
