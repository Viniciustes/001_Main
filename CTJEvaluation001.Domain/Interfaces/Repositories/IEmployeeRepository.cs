using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Entities.Auth;
using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Employee GetByChapa(string chapa);
        IEnumerable<Employee> GetByName(string name);
        IEnumerable<Employee> GetByNameAndFuncao(string name, string inFuncoes);
        Person GetPersonByChapa(string chapa);
        Annotation GetAnnotationByPersonAndNro(Person person, int nro, AuthUser authUser);
        IEnumerable<Annotation> GetAnnotationsByPerson(Person person, AuthUser authUser);
        IEnumerable<Annotation> GetAllAnnotationsByPerson(Person person, AuthUser authUser);
        AnnotationSave Save(AnnotationSave obj, AuthUser authUser);
        AnnotationSave Update(AnnotationSave obj, AuthUser authUser);
    }
}