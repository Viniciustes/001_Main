using CTJEvaluation001.Domain.Interfaces.Repositories;
using System.Linq;
using CTJEvaluation001.Domain.Entities;
using System.Data.SqlClient;

namespace CTJEvaluation001.Infra.Data.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public Person GetByEmployee(Employee employee)
        {
            return Db.Database.SqlQuery<Person>("SELECT B.CODIGO AS 'ID', B.NOME AS 'NAME', B.CPF, B.GRAUINSTRUCAO FROM PFUNC AS A WITH(NOLOCK) INNER JOIN PPESSOA AS B WITH (NOLOCK)ON B.CODIGO = A.CODPESSOA WHERE A.CHAPA = @Chapa AND A.CODSITUACAO != 'D'", new object[] { new SqlParameter("@Chapa", employee.Chapa) }).FirstOrDefault();
        }
    }
}
