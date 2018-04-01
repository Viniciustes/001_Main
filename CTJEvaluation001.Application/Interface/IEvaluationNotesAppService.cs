using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Entities.Auth;
using System.Collections.Generic;

namespace CTJEvaluation001.Application.Interface
{
    public interface IEvaluationNotesAppService
    {
        IEnumerable<Employee> GetByName(string name, AuthUser authUser);
        Annotation Save(AnnotationSave obj, AuthUser authUser);
        Annotation Update(AnnotationSave obj, AuthUser authUser);
    }
}
