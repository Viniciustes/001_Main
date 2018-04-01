using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTJEvaluation001.MVC.Controllers.Reports
{
    public class RapReportController : Controller
    {
        // GET: RapReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RapFiltro()
        {
            return View();
        }

        public ActionResult RapReport(string chapa, int ano)
        {
            return View();
        }
    }
}