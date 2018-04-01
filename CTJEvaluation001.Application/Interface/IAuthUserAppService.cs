using CTJEvaluation001.Domain.Entities.Auth;
using System.Web;

namespace CTJEvaluation001.Application.Interface
{
    public interface IAuthUserAppService
    {
        bool InitSession(string username, HttpSessionStateBase session);
        bool LoginIsValidWithTotvsAuth(string username);
        bool CloseSession();
        AuthUser AuthUser();
        AuthUser UpdateContextoAno(int contextoAno);
        bool IsAuthenticated();
    }
}