using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Repositories;
using CTJEvaluation001.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using CTJEvaluation001.Domain.Entities.Auth;
using System;

namespace CTJEvaluation001.Domain.Services
{
    public class EmployeeService : ServiceBase<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPersonRepository _personRepository;

        public EmployeeService(IEmployeeRepository employeeRepository,
            IPersonRepository personRepository) 
            : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _personRepository = personRepository;
        }

        public Employee GetByChapa(string chapa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetByName(string name, AuthUser authUser)
        {
            IEnumerable<Employee> employees = _employeeRepository.GetByName(name);

            foreach (var item in employees)
            {
                item.Person = _personRepository.GetByEmployee(item);
                item.Person.Annotations = _employeeRepository.GetAnnotationsByPerson(item.Person, authUser);
            }

            return employees;
        }

        public IEnumerable<Employee> GetByNameAndFuncao(string name, AuthUser authUser, string inFuncoes)
        {
            IEnumerable<Employee> employees = _employeeRepository.GetByNameAndFuncao(name, inFuncoes);

            foreach (var item in employees)
            {
                item.Person = _personRepository.GetByEmployee(item);
                item.Person.Annotations = _employeeRepository.GetAnnotationsByPerson(item.Person, authUser);
            }

            return employees;
        }

        public Annotation Save(AnnotationSave obj, AuthUser authUser)
        {
            Person person = _employeeRepository.GetPersonByChapa(obj.Chapa);
            obj.Nro = GetNextNroAnnotationByPerson(person, authUser);
            _employeeRepository.Save(obj, authUser);

            return _employeeRepository.GetAnnotationByPersonAndNro(person, obj.Nro, authUser);
        }

        public Annotation Update(AnnotationSave obj, AuthUser authUser)
        {
            Person person = _employeeRepository.GetPersonByChapa(obj.Chapa);
            _employeeRepository.Update(obj, authUser);

            return _employeeRepository.GetAnnotationByPersonAndNro(person, obj.Nro, authUser);
        }

        private int GetNextNroAnnotationByPerson(Person person, AuthUser authUser)
        {
            IEnumerable<Annotation> annotations = _employeeRepository.GetAllAnnotationsByPerson(person, authUser);

            if (annotations != null)
            {
                return (annotations.Count() >= 1) ? annotations.Max(x => x.Nro) + 1 : 1;
            }
            else
            {
                return 1;
            }
        }
    }
}
