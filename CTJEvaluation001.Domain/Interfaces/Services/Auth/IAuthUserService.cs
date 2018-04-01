using CTJEvaluation001.Domain.Entities.Auth;

namespace CTJEvaluation001.Domain.Interfaces.Services.Auth
{
    public interface IAuthUserService
    {
        AuthUser GetByCodigo(string codigo);
        bool LoginIsValidWithTotvsAuth(string username);
    }
}
