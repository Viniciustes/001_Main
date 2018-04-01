using System.Web;
using CTJEvaluation001.Application.Interface;
using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Services;
using CTJEvaluation001.Infra.CrossCutting.Interfaces;
using CTJEvaluation001.Domain.Entities.Auth;
using System.Collections.Generic;

namespace CTJEvaluation001.Application
{
    public class SelfEvaluationAppService : ISelfEvaluationAppService
    {
        private readonly ISelfEvaluationService _selfEvaluationService;
        private readonly IFileUploadService _selfFileUploadService;
        private readonly IObserverService _observerService;
        private readonly IObservedService _observedService;
        private readonly IAuthUserAppService _authUserAppService;

        public SelfEvaluationAppService(ISelfEvaluationService selfEvaluationServiceBase,
            IFileUploadService fileUploadService, 
            IObserverService observerService,
            IObservedService observedService,
            IAuthUserAppService authUserAppService)
        {
            _selfEvaluationService = selfEvaluationServiceBase;
            _selfFileUploadService = fileUploadService;
            _observerService = observerService;
            _observedService = observedService;
            _authUserAppService = authUserAppService;
        }


        public SelfEvaluation Get(string chapa, int contextoAno)
        {
            return _selfEvaluationService.Get(_observedService.GetByChapa(chapa), contextoAno);
        }

        public DigitalLiteracy Save(DigitalLiteracy obj, AuthUser authUser)
        {
            return _selfEvaluationService.Save(obj, authUser);
        }

        public DigitalLiteracy Remove(DigitalLiteracy obj, AuthUser authUser)
        {
            return _selfEvaluationService.Remove(obj, authUser);
        }

        public ProfessionalDevelopment Save(ProfessionalDevelopment obj, AuthUser authUser)
        {
            return _selfEvaluationService.Save(obj, authUser);
        }

        public ProfessionalDevelopment Remove(ProfessionalDevelopment obj, AuthUser authUser)
        {
            return _selfEvaluationService.Remove(obj, authUser);
        }

        public ProjectActivity Save(ProjectActivity obj, AuthUser authUser)
        {
            return _selfEvaluationService.Save(obj, authUser);
        }

        public ProjectActivity Remove(ProjectActivity obj, AuthUser authUser)
        {
            return _selfEvaluationService.Remove(obj, authUser);
        }

        public FileUpload UploadCertificate(HttpFileCollectionBase files, AuthUser authUser)
        {
            return _selfFileUploadService.Upload(files, authUser);
        }

        public SelfEvalSave Save(SelfEvalSave obj, AuthUser authUser)
        {
            return _selfEvaluationService.Save(obj, authUser);
        }

        public FileUpload GetById(int? id)
        {
            return _selfEvaluationService.GetById(id);
        }

        public IEnumerable<SelfEvaluation> GetAllByObserver(int contextoAno)
        {
            var user = _authUserAppService.AuthUser();
            var observer = _observerService.GetByChapa(user.Chapa);

            return _selfEvaluationService.GetAllByObserver(observer, contextoAno);
        }
    }
}