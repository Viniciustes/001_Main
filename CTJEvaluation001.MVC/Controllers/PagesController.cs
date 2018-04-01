using System.Web.Mvc;

namespace CTJEvaluation001.MVC.Controllers
{
    public class PagesController : Controller
    {
        public ViewResult Display404NotFoundPage()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}