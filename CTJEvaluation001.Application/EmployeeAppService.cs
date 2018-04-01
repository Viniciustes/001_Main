using CTJEvaluation001.Application.Interface;
using CTJEvaluation001.Domain.Entities;
using System.Collections.Generic;
using CTJEvaluation001.Domain.Interfaces.Services;
using CTJEvaluation001.Domain.Entities.Auth;

namespace CTJEvaluation001.Application
{
    public class EmployeeAppService : AppServiceBase<Employee>, IEmployeeAppService
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeAppService(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        public IEnumerable<Employee> GetByName(string name, AuthUser authUser)
        {
            return _employeeService.GetByName(name, authUser);
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
