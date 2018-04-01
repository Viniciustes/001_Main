using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Repositories;
using System.Data.SqlClient;
using System.Linq;

namespace CTJEvaluation001.Infra.Data.Repositories
{
    public class ObserverRepository : RepositoryBase<Observer>, IObserverRepository
    {
        public Observer GetByChapa(string chapa)
        {
            return Db.Observer.SqlQuery("EXECUTE [dbo].[SPU_GETOBSERVERBYCHAPA] @CHAPA", new SqlParameter("@CHAPA", chapa)).FirstOrDefault();
        }
    }
}
