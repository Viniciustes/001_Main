using AutoMapper;
using CTJEvaluation001.Application.Interface;
using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.MVC.Resources;
using CTJEvaluation001.MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CTJEvaluation001.MVC.Controllers
{
    public class ObservationController : Controller
    {
        private readonly IObservationAppService _observationApp;
        private readonly IAuthUserAppService _selfAuthUserAppService;
        private readonly ISelfEvaluationAppService _selfEvaluationAppService;

        public ObservationController(IObservationAppService observationApp,
            IAuthUserAppService selfAuthUserAppService, ISelfEvaluationAppService selfEvaluationAppService)
        {
            _observationApp = observationApp;
            _selfAuthUserAppService = selfAuthUserAppService;
            _selfEvaluationAppService = selfEvaluationAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var teste = _observationApp.GetObservationDashboard(_selfAuthUserAppService.AuthUser(), _selfAuthUserAppService.AuthUser().ContextoAno);

            var observationViewModel = Mapper.Map<ObservationDashboard, ObservationDashboardViewModel>(teste);

            if (!observationViewModel.observations.Any())
            {
                return View("../Pages/Display404NotFoundPage");
            }

            return View(observationViewModel);
        }

        public ActionResult Edit(string id)
        {
            var observation = _observationApp.GetByIdObserver(_selfAuthUserAppService.AuthUser(), id);
            var observationViewModel = Mapper.Map<Observation, ObservationViewModel>(observation);

            if (observation.CodAvaliacao.Contains("-F-"))
            {
                return View("Edit-F", observationViewModel);
            }
            else
            {
                return View(observationViewModel);
            }
        }

        public ActionResult Print(string id)
        {
            var observation = _observationApp.GetByIdObserver(_selfAuthUserAppService.AuthUser(), id);
            var observationViewModel = Mapper.Map<Observation, ObservationViewModel>(observation);
            return View(observationViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ObservationSaveViewModel observation)
        {
            var action = Request.Form["action"];

            if (action == "Finish")
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var observationViewModel = Mapper.Map<ObservationSaveViewModel, ObservationSave>(observation);
                        _observationApp.Save(_selfAuthUserAppService.AuthUser(), observationViewModel);
                        _observationApp.Done(_selfAuthUserAppService.AuthUser(), observationViewModel);
                        TempData["Sucess"] = Messages.SalveSuccess;

                        return RedirectToAction("Index");
                    }
                    catch (System.Exception e)
                    {
                        TempData["Error"] = e.Message.ToString();
                        return Redirect("/Observation/Edit/" + observation.CodAvaliacao + observation.ChapaAvaliado);
                    }
                    
                }
                else
                {
                    TempData["Error"] = "Para finalizar todas as questões devem ser respondidas.";
                    return Redirect("/Observation/Edit/"+observation.CodAvaliacao+observation.ChapaAvaliado);
                }                
            }
            else
            {
                try
                {
                    var observationViewModel = Mapper.Map<ObservationSaveViewModel, ObservationSave>(observation);
                    _observationApp.Save(_selfAuthUserAppService.AuthUser(), observationViewModel);
                    TempData["Sucess"] = Messages.SalveSuccess;
                    return RedirectToAction("Index");
                }
                catch (System.Exception e)
                {
                    TempData["Error"] = e.Message.ToString();
                    return Redirect("/Observation/Edit/" + observation.CodAvaliacao + observation.ChapaAvaliado);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveF(ObservationSaveFinalViewModel observation)
        {
            var action = Request.Form["action"];

            if (action == "Finish")
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var observationViewModel = Mapper.Map<ObservationSaveFinalViewModel, ObservationSaveFinal>(observation);
                        _observationApp.SaveF(_selfAuthUserAppService.AuthUser(), observationViewModel);
                        _observationApp.DoneF(_selfAuthUserAppService.AuthUser(), observationViewModel);
                        TempData["Sucess"] = Messages.SalveSuccess;

                        return RedirectToAction("Index");
                    }
                    catch (System.Exception e)
                    {
                        TempData["Error"] = e.Message.ToString();
                        return Redirect("/Observation/Edit/" + observation.CodAvaliacao + observation.ChapaAvaliado);
                    }

                }
                else
                {
                    TempData["Error"] = "Para finalizar todas as questões devem ser respondidas.";
                    return Redirect("/Observation/Edit/" + observation.CodAvaliacao + observation.ChapaAvaliado);
                }
            }
            else
            {
                try
                {
                    var observationViewModel = Mapper.Map<ObservationSaveFinalViewModel, ObservationSaveFinal>(observation);
                    _observationApp.SaveF(_selfAuthUserAppService.AuthUser(), observationViewModel);
                    TempData["Sucess"] = Messages.SalveSuccess;
                    return RedirectToAction("Index");
                }
                catch (System.Exception e)
                {
                    TempData["Error"] = e.Message.ToString();
                    return Redirect("/Observation/Edit/" + observation.CodAvaliacao + observation.ChapaAvaliado);
                }
            }
        }

        public ActionResult ListSelfEvaluation()
        {
            var selfEvaluation = _selfEvaluationAppService.GetAllByObserver(_selfAuthUserAppService.AuthUser().ContextoAno);
            var selfEvaluationViewModel = Mapper.Map<IEnumerable<SelfEvaluation>, IEnumerable<SelfEvaluationViewModel>>(selfEvaluation);

            return View(selfEvaluationViewModel);
        }

        public ActionResult EditSelfEvaluation(string id)
        {
            var selfEvaluation = _selfEvaluationAppService.Get(id, _selfAuthUserAppService.AuthUser().ContextoAno);
            var selfEvaluationViewModel = Mapper.Map<SelfEvaluation, SelfEvaluationViewModel>(selfEvaluation);
            ViewBag.Mostar = false;
            ViewBag.Viewer = "OBSERVER";
            return View("../SelfEvaluation/Index", selfEvaluationViewModel);
        }
    }
}