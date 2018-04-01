using AutoMapper;
using CTJEvaluation001.Application.Interface;
using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTJEvaluation001.MVC.Controllers
{
    public class AnnotationController : Controller
    {
        private readonly IAnnotationTypeAppService _annotationTypeApp;
        private readonly IAuthUserAppService _authUserAppService;
        private readonly IEvaluationNotesAppService _evaluationNotesAppService;

        public AnnotationController(IEmployeeAppService employeeApp,
            IAnnotationTypeAppService annotationTypeApp,
            IAuthUserAppService authUserAppService,
            IEvaluationNotesAppService evaluationNotesAppService)
        {
            _annotationTypeApp = annotationTypeApp;
            _authUserAppService = authUserAppService;
            _evaluationNotesAppService = evaluationNotesAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GeyEmployeesByName(string search)
        {
            IEnumerable<Employee> employees = _evaluationNotesAppService.GetByName(search, _authUserAppService.AuthUser());
            return Json(employees);
        }

        [HttpPost]
        public JsonResult GeyAnnotationsType()
        {
            IEnumerable<AnnotationType> annotationsType = _annotationTypeApp.GetAll(_authUserAppService.AuthUser());
            return Json(annotationsType);
        }

        [HttpPost]
        public JsonResult SaveAnnotation(AnnotationSaveViewModel viewModel)
        {
            var entitie = Mapper.Map<AnnotationSaveViewModel, AnnotationSave>(viewModel);

            if (entitie.Nro == 0)
            {
                return Json(_evaluationNotesAppService.Save(entitie, _authUserAppService.AuthUser()));
            }
            else
            {
                return Json(_evaluationNotesAppService.Update(entitie, _authUserAppService.AuthUser()));
            }
        }
    }
}