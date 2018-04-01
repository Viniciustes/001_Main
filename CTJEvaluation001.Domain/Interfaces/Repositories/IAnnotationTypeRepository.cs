using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Entities.Auth;
using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Interfaces.Repositories
{
    public interface IAnnotationTypeRepository
    {
        AnnotationType GetById(int id, AuthUser authUser);
        IEnumerable<AnnotationType> GetAll(AuthUser authUser);
    }
}