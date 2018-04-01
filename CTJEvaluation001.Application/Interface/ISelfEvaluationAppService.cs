using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Entities.Auth;
using System.Collections.Generic;
using System.Web;

namespace CTJEvaluation001.Application.Interface
{
    public interface ISelfEvaluationAppService
    {
        SelfEvaluation Get(string chapa, int contextoAno);
        ProfessionalDevelopment Save(ProfessionalDevelopment obj, AuthUser authUser);
        ProfessionalDevelopment Remove(ProfessionalDevelopment obj, AuthUser authUser);
        DigitalLiteracy Save(DigitalLiteracy obj, AuthUser authUser);
        DigitalLiteracy Remove(DigitalLiteracy obj, AuthUser authUser);
        ProjectActivity Save(ProjectActivity obj, AuthUser authUser);
        ProjectActivity Remove(ProjectActivity obj, AuthUser authUser);
        FileUpload UploadCertificate(HttpFileCollectionBase files, AuthUser authUser);
        SelfEvalSave Save(SelfEvalSave obj, AuthUser authUser);
        FileUpload GetById(int? id);

        IEnumerable<SelfEvaluation> GetAllByObserver(int contextoAno);
    }
}
