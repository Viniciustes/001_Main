using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Entities.Auth;
using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Interfaces.Services
{
    public interface ISelfEvaluationService
    {
        SelfEvaluation Get(Observed authUser, int contextoAno);
        ProfessionalDevelopment Save(ProfessionalDevelopment obj, AuthUser authUser);
        ProfessionalDevelopment Remove(ProfessionalDevelopment obj, AuthUser authUser);
        DigitalLiteracy Save(DigitalLiteracy obj, AuthUser authUser);
        DigitalLiteracy Remove(DigitalLiteracy obj, AuthUser authUser);
        ProjectActivity Save(ProjectActivity obj, AuthUser authUser);
        ProjectActivity Remove(ProjectActivity obj, AuthUser authUser);
        SelfEvalSave Save(SelfEvalSave obj, AuthUser authUser);
        FileUpload GetById(int? id);

        IEnumerable<SelfEvaluation> GetAllByObserver(Observer observer, int contextoAno);
    }
}
