using CTJEvaluation001.Application.Interface;
using System.Web.Mvc;
using AutoMapper;
using CTJEvaluation001.MVC.ViewModels;
using CTJEvaluation001.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CTJEvaluation001.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IObservationAppService _observationApp;
        private readonly IAuthUserAppService _selfAuthUserAppService;

        public HomeController(IObservationAppService observationApp,
            IAuthUserAppService authUserAppService)
        {
            _observationApp = observationApp;
            _selfAuthUserAppService = authUserAppService;
        }

        public ActionResult Index()
        {
            if (_selfAuthUserAppService.AuthUser().Codperfil == "CTJE.Anotador" || _selfAuthUserAppService.AuthUser().Codperfil == "CTJE.Observador")
            {
                return RedirectToAction("Index", "Annotation");
            }

            var observationViewModel = Mapper.Map<IEnumerable<Observation>, IEnumerable<ObservationViewModel>>(_observationApp.GetAll(_selfAuthUserAppService.AuthUser(), _selfAuthUserAppService.AuthUser().ContextoAno));

            if (!observationViewModel.Any())
            {
                return View("../Pages/Display404NotFoundPage");
            }

            return View(observationViewModel);
        }

        public ActionResult Observation(string id)
        {
            if (_selfAuthUserAppService.AuthUser().Codperfil == "CTJE.Anotador" || _selfAuthUserAppService.AuthUser().Codperfil == "CTJE.Observador")
            {
                return RedirectToAction("Index", "Annotation");
            }

            var observation = _observationApp.GetById(_selfAuthUserAppService.AuthUser(), id);
            var observationViewModel = Mapper.Map<Observation, ObservationViewModel>(observation);

            return View(observationViewModel);
        }
    }
}