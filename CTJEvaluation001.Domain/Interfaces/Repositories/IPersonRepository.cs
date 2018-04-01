using CTJEvaluation001.Domain.Entities;
using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Person GetByEmployee(Employee employee);
    }
}
