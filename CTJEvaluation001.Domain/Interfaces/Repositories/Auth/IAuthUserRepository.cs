using CTJEvaluation001.Domain.Entities.Auth;

namespace CTJEvaluation001.Domain.Interfaces.Repositories.Auth
{
    public interface IAuthUserRepository
    {
        AuthUser GetByCodigo(string codigo);
    }
}
