using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Entities.Auth;
using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Interfaces.Repositories
{
    public interface ISelfEvaluationRepository : IRepositoryBase<SelfEvaluation>
    {
        SelfEvaluation Get(Observed observed, int contextoAno);
        SelfEvaluation GenerateByYear(Observed observed, int contextoAno);
        IEnumerable<ProfessionalDevelopment> GetProfessionalDevelopmentByAnoAndChapa(Observed observed, int contextoAno);
        IEnumerable<DigitalLiteracy> GetDigitalLiteracyByAnoAndChapa(Observed observed, int contextoAno);
        IEnumerable<ProjectActivity> GetProjectActivityByAnoAndChapa(Observed observed, int contextoAno);
        IEnumerable<Course> GetCourseParticipated(int[] coursesList, Observed observed, int contextoAno);
        IEnumerable<Class> GetClassesParticipatedByCourseId(int CourseId, Observed observed, int contextoAno);
        ProfessionalDevelopment Save(ProfessionalDevelopment obj, AuthUser authUser);
        ProfessionalDevelopment Update(ProfessionalDevelopment obj, int? Ano, int? Tipo, int? Nseq, AuthUser authUser);
        ProfessionalDevelopment Remove(ProfessionalDevelopment obj, AuthUser authUser);
        DigitalLiteracy Save(DigitalLiteracy obj, AuthUser authUser);
        DigitalLiteracy Update(DigitalLiteracy obj, int? Ano, int? Nseq, AuthUser authUser);
        DigitalLiteracy Remove(DigitalLiteracy obj, AuthUser authUser);
        ProjectActivity Save(ProjectActivity obj, AuthUser authUser);
        ProjectActivity Update(ProjectActivity obj, int Ano, string Chapa, string CtjEvalId, AuthUser authUser);
        ProjectActivity Remove(ProjectActivity obj, AuthUser authUser);
        SelfEvalSave Save(SelfEvalSave obj, AuthUser authUser);
        IEnumerable<SelfEvaluation> GetAllByObserver(Observer observer, int contextoAno);
    }
}

