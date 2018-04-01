using CTJEvaluation001.Application.Interface;
using CTJEvaluation001.Domain.Entities.Auth;
using CTJEvaluation001.Domain.Interfaces.Services.Auth;
using System;
using System.Web;
using System.Web.Security;

namespace CTJEvaluation001.Application
{
    public class AuthUserAppService : IAuthUserAppService
    {
        private readonly IAuthUserService _selfAuthUserService;

        public AuthUserAppService(IAuthUserService authUserService)
        {
            _selfAuthUserService = authUserService;
        }

        public bool InitSession(string username, HttpSessionStateBase session)
        {
            // get AuthUser
            AuthUser authUser = _selfAuthUserService.GetByCodigo(username);
            //authUser.ContextoAno = Convert.ToInt32(DateTime.Now.Year.ToString());
            authUser.ContextoAno = DateTime.Now.Year;

            // set Session
            session["user"] = authUser;

            return true;
        }

        public bool LoginIsValidWithTotvsAuth(string username)
        {
            return _selfAuthUserService.LoginIsValidWithTotvsAuth(username);
        }

        public bool CloseSession()
        {
            HttpContext.Current.Session.RemoveAll();
            return true;
        }

        public AuthUser AuthUser()
        {
            var user = HttpContext.Current.Session["user"] as AuthUser;

            if (user == null)
            {
                var username = HttpContext.Current.User.Identity.Name;
                AuthUser authUser = _selfAuthUserService.GetByCodigo(username);
                //authUser.ContextoAno = Convert.ToInt32(DateTime.Now.Year.ToString());
                authUser.ContextoAno = DateTime.Now.Year;
                HttpContext.Current.Session["user"] = authUser;
            }
                
            return HttpContext.Current.Session["user"] as AuthUser;
        }

        public AuthUser UpdateContextoAno(int contextoAno)
        {
            var authUser = AuthUser();

            authUser.ContextoAno = contextoAno;
            HttpContext.Current.Session["user"] = authUser;

            return HttpContext.Current.Session["user"] as AuthUser;
        }

        public bool IsAuthenticated()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}
