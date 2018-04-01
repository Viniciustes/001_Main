using AutoMapper;
using CTJEvaluation001.Application.Interface;
using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.MVC.ViewModels;
using System.Web.Mvc;

namespace CTJEvaluation001.MVC.Controllers
{
    public class SelfEvaluationController : Controller
    {
        private readonly ISelfEvaluationAppService _selfEvaluationApp;
        private readonly IAuthUserAppService _selfAuthUserAppService;

        public SelfEvaluationController(ISelfEvaluationAppService selfEvaluationApp,
            IAuthUserAppService authUserAppService)
        {
            _selfEvaluationApp = selfEvaluationApp;
            _selfAuthUserAppService = authUserAppService;
        }

        public ActionResult Index()
        {
            if (_selfAuthUserAppService.AuthUser().Codperfil == "CTJE.Anotador" || _selfAuthUserAppService.AuthUser().Codperfil == "CTJE.Observador")
            {
                return RedirectToAction("Index", "Annotation");
            }

            // TODO: Fazer os ajustes nnecessários.
            var selfEvaluationViewModel = Mapper.Map<SelfEvaluation, SelfEvaluationViewModel>(_selfEvaluationApp.Get(_selfAuthUserAppService.AuthUser().Chapa, _selfAuthUserAppService.AuthUser().ContextoAno));

            if (selfEvaluationViewModel == null)
            {
                return View("../Pages/Display404NotFoundPageSelfEvaluation");
            }

            return View(selfEvaluationViewModel);
        }

        [HttpPost]
        public JsonResult ProfissionalDevelpment(ProfissionalDevelpmentViewModel viewModel)
        {
            var files = Request.Files;
            var entitie = Mapper.Map<ProfissionalDevelpmentViewModel, ProfessionalDevelopment>(viewModel);
            FileUpload uploadFile;
            
            if (files.Count > 0)
            {
                uploadFile = _selfEvaluationApp.UploadCertificate(Request.Files,
                _selfAuthUserAppService.AuthUser());
            }
            else
            {
                uploadFile = _selfEvaluationApp.GetById(entitie.ImagemId);
            }
            
            entitie.ImagemId = uploadFile.Id;
            entitie.Imagem = uploadFile;
            var dados = _selfEvaluationApp.Save(entitie, _selfAuthUserAppService.AuthUser());

            return Json(dados);
        }

        [HttpPost]
        public JsonResult ProfissionalDevelpmentDelete(ProfissionalDevelpmentViewModel viewModel)
        {
            var entitie = Mapper.Map<ProfissionalDevelpmentViewModel, ProfessionalDevelopment>(viewModel);
            var dados = _selfEvaluationApp.Remove(entitie, _selfAuthUserAppService.AuthUser());

            return Json(dados);
        }

        [HttpPost]
        public JsonResult DigitalLiteracy(DigitalLiteracyViewModel viewModel)
        {
            var entitie = Mapper.Map<DigitalLiteracyViewModel, DigitalLiteracy>(viewModel);
            var dados = _selfEvaluationApp.Save(entitie, _selfAuthUserAppService.AuthUser());

            return Json(dados);
        }

        [HttpPost]
        public JsonResult DigitalLiteracyDelete(DigitalLiteracyViewModel viewModel)
        {
            var entitie = Mapper.Map<DigitalLiteracyViewModel, DigitalLiteracy>(viewModel);
            var dados = _selfEvaluationApp.Remove(entitie, _selfAuthUserAppService.AuthUser());

            return Json(dados);
        }

        [HttpPost]
        public JsonResult ProjectActivity(ProjectActivityViewModel viewModel)
        {
            var entitie = Mapper.Map<ProjectActivityViewModel, ProjectActivity>(viewModel);
            var dados = _selfEvaluationApp.Save(entitie, _selfAuthUserAppService.AuthUser());
            return Json(dados);
        }

        [HttpPost]
        public JsonResult ProjectActivityDelete(ProjectActivityViewModel viewModel)
        {
            var entitie = Mapper.Map<ProjectActivityViewModel, ProjectActivity>(viewModel);
            var dados = _selfEvaluationApp.Remove(entitie, _selfAuthUserAppService.AuthUser());
            return Json(dados);
        }

        [HttpPost]
        public JsonResult Save(SelfEvalSaveViewModel viewModel)
        {
            var entitie = Mapper.Map<SelfEvalSaveViewModel, SelfEvalSave>(viewModel);

            if (Request.Files.Count > 0)
            {
                var uploadFile = _selfEvaluationApp.UploadCertificate(Request.Files, _selfAuthUserAppService.AuthUser());
                entitie.DegreeImageID = uploadFile.Id;
                entitie.DegreeImage = uploadFile;
            }
            var dados = _selfEvaluationApp.Save(entitie, _selfAuthUserAppService.AuthUser());

            return Json(dados);
        }

        [HttpGet]
        public ActionResult Print()
        {
            var chapa = Request.Url.Segments[3];

            var selfEvaluationViewModel = Mapper.Map<SelfEvaluation, SelfEvaluationViewModel>(_selfEvaluationApp.Get(chapa, _selfAuthUserAppService.AuthUser().ContextoAno));

            if (selfEvaluationViewModel == null)
            {
                return View("../Pages/Display404NotFoundPageSelfEvaluation");
            }

            return View(selfEvaluationViewModel);
        }
    }
}