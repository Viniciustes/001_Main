using CTJEvaluation001.Domain.Entities.Auth;
using CTJEvaluation001.Domain.Interfaces.Services.Auth;
using CTJEvaluation001.Domain.Interfaces.Repositories.Auth;

namespace CTJEvaluation001.Domain.Services.Auth
{
    public class AuthUserService : IAuthUserService
    {
        private readonly IAuthUserRepository _selfAuthUserRepository;

        public AuthUserService(IAuthUserRepository selfAuthUserRepository)
        {
            _selfAuthUserRepository = selfAuthUserRepository;
        }

        public AuthUser GetByCodigo(string codigo)
        {
            return _selfAuthUserRepository.GetByCodigo(codigo);
        }

        public bool LoginIsValidWithTotvsAuth(string username)
        {
            return _selfAuthUserRepository.GetByCodigo(username) != null;
        }
    }
}
