using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Entities.Auth;
using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Interfaces.Services
{
    public interface IAnnotationTypeService
    {
        AnnotationType GetById(int id, AuthUser authUser);
        IEnumerable<AnnotationType> GetAll(AuthUser authUser);
    }
}
