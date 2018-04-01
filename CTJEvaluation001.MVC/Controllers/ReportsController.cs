using System.Web.Mvc;

namespace CTJEvaluation001.MVC.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index(string nameReport)
        {
            switch (nameReport)
            {
                case "ManfAvaliado":
                    return View();
                case "TeacObservReport":
                    return View();
                case "ChartCollection":
                    return View();
                case "Rap":
                    return View();
                case "AutAvaliacoes":
                    return View();
            }

            return View();
        }
    }
}