using System.Collections.Generic;
using CTJEvaluation001.Application.Interface;
using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Services;
using CTJEvaluation001.Domain.Entities.Auth;

namespace CTJEvaluation001.Application
{
    public class AnnotationTypeAppService : IAnnotationTypeAppService
    {
        private readonly IAnnotationTypeService _annotationTypeService;

        public AnnotationTypeAppService(IAnnotationTypeService annotationTypeService)
        {
            _annotationTypeService = annotationTypeService;
        }

        public IEnumerable<AnnotationType> GetAll(AuthUser authUser)
        {
            return _annotationTypeService.GetAll(authUser);
        }

        public AnnotationType GetById(int id, AuthUser authUser)
        {
            return _annotationTypeService.GetById(id, authUser);
        }
    }
}
