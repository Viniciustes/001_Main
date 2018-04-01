using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Entities.Auth;
using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Interfaces.Services
{
    public interface IEmployeeService : IServiceBase<Employee>
    {
        IEnumerable<Employee> GetByName(string name, AuthUser authUser);
        IEnumerable<Employee> GetByNameAndFuncao(string name, AuthUser authUser, string inFuncoes);
        Annotation Save(AnnotationSave obj, AuthUser authUser);
        Annotation Update(AnnotationSave obj, AuthUser authUser);
        Employee GetByChapa(string chapa);
    }
}
