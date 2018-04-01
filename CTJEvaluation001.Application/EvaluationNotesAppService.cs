using CTJEvaluation001.Application.Interface;
using CTJEvaluation001.Domain.Entities;
using System.Collections.Generic;
using CTJEvaluation001.Domain.Interfaces.Services;
using CTJEvaluation001.Domain.Entities.Auth;

namespace CTJEvaluation001.Application
{
    public class EvaluationNotesAppService : IEvaluationNotesAppService
    {
        private readonly IEmployeeService _employeeService;

        public EvaluationNotesAppService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IEnumerable<Employee> GetByName(string name, AuthUser authUser)
        {
            return _employeeService.GetByNameAndFuncao(name, authUser, "0029, 0034, 0051, 0068, 0040");
        }

        public Annotation Save(AnnotationSave obj, AuthUser authUser)
        {
            return _employeeService.Save(obj, authUser);
        }

        public Annotation Update(AnnotationSave obj, AuthUser authUser)
        {
            return _employeeService.Update(obj, authUser);
        }
    }
}
