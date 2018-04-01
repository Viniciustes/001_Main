using System.Collections.Generic;
using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Services;
using CTJEvaluation001.Domain.Interfaces.Repositories;
using CTJEvaluation001.Domain.Entities.Auth;

namespace CTJEvaluation001.Domain.Services
{
    public class AnnotationTypeService : IAnnotationTypeService
    {
        private readonly IAnnotationTypeRepository _annotationTypeRepository;

        public AnnotationTypeService(IAnnotationTypeRepository annotationTypeRepository)
        {
            _annotationTypeRepository = annotationTypeRepository;
        }

        public IEnumerable<AnnotationType> GetAll(AuthUser authUser)
        {
            return _annotationTypeRepository.GetAll(authUser);
        }

        public AnnotationType GetById(int id, AuthUser authUser)
        {
            return _annotationTypeRepository.GetById(id, authUser);
        }
    }
}
