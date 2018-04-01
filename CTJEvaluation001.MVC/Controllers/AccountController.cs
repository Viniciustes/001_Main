using System.Web.Mvc;
using System.Web.Security;
using CTJEvaluation001.Application.Interface;


namespace CTJEvaluation001.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthUserAppService _selfAuthUserAppService;

        public AccountController(IAuthUserAppService authUserAppService)
        {
            _selfAuthUserAppService = authUserAppService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");
                return View(model);
            }

            // TODO: Descomentar o código abaixo quando levar para produção.
            if (/*Membership.ValidateUser(model.UserName, model.Password) &&*/
                 _selfAuthUserAppService.LoginIsValidWithTotvsAuth(model.UserName))
            {
                _selfAuthUserAppService.InitSession(model.UserName, Session);

                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                switch(_selfAuthUserAppService.AuthUser().Codperfil)
                {
                    case "CTJE.Teacher":
                        return RedirectToAction("Index", "Home");
                    case "CTJE.Observador":
                        return RedirectToAction("Index", "Observation");
                    case "CTJE.Anotador":
                        return RedirectToAction("Index", "Annotation");
                }

                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            _selfAuthUserAppService.CloseSession();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult ChangeYearContext(int contextoAno)
        {
            _selfAuthUserAppService.UpdateContextoAno(contextoAno);
            return Json(new { Success = true });
        }

        public bool IsAuthenticated()
        {
            return _selfAuthUserAppService.IsAuthenticated();
        }
    }
}