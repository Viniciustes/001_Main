using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Repositories;
using System.Data.SqlClient;
using System.Linq;

namespace CTJEvaluation001.Infra.Data.Repositories
{
    public class ObservedRepository : RepositoryBase<Observed>, IObservedRepository
    {
        public Observed GetByChapa(string chapa)
        {
            return Db.Observed.SqlQuery("EXECUTE [dbo].[SPU_GETOBSERVEDBYCHAPA] @CHAPA", new SqlParameter("@CHAPA", chapa)).FirstOrDefault();
        }
    }
}