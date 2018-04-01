using System.Linq;
using System.Collections.Generic;
using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Repositories;
using System.Data.SqlClient;
using CTJEvaluation001.Domain.Entities.Auth;
 
namespace CTJEvaluation001.Infra.Data.Repositories
{
    public class AnnotationTypeRepository : RepositoryBase<AnnotationType>, IAnnotationTypeRepository
    {
        public IEnumerable<AnnotationType> 
            GetAll(AuthUser authUser)
        {
            var sql = "SELECT CONVERT(INT, A.CODCLIENTE) AS 'ID', A.DESCRICAO AS 'DESCRIPTION' FROM PTPANOTACAO AS A WITH (NOLOCK) WHERE A.CODCLIENTE IN (SELECT Z.CODCLIENTE FROM GCONSIST Z(NOLOCK) WHERE Z.CODTABELA = 'CTJEVAL002' AND Z.DESCRICAO LIKE @Perfil)";

            return Db.Database.SqlQuery<AnnotationType>(sql, new object[] { new SqlParameter("@Perfil", "%" + authUser.Codperfil + "%") }).ToList();
        }

        public AnnotationType GetById(int id, AuthUser authUser)
        {
            var sql = "SELECT A.CODCLIENTE AS 'ID', A.DESCRICAO AS 'DESCRIPTION' FROM PTPANOTACAO AS A WITH (NOLOCK) WHERE A.CODCLIENTE IN (SELECT Z.CODCLIENTE FROM GCONSIST Z(NOLOCK) WHERE Z.CODTABELA = 'CTJEVAL002' AND Z.DESCRICAO LIKE @Perfil) AND A.CODCLIENTE=@Id";

            return Db.Database.SqlQuery<AnnotationType>(sql, new object[] { new SqlParameter("@Id", id), new SqlParameter("@Perfil", "%" + authUser.Codperfil + "%") }).FirstOrDefault();
        }
    }
}