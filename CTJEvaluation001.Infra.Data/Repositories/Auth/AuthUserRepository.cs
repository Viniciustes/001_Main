using CTJEvaluation001.Domain.Entities.Auth;
using CTJEvaluation001.Domain.Interfaces.Repositories.Auth;
using System.Data.SqlClient;
using System.Linq;

namespace CTJEvaluation001.Infra.Data.Repositories.Auth
{
    public class AuthUserRepository : RepositoryBase<AuthUser>,
        IAuthUserRepository
    {
        public AuthUser GetByCodigo(string codigo)
        {
            var sql = "SELECT TOP 1 A.CODUSUARIO, A.CODUSUARIOREDE, B.CODIGO AS 'CODPESSOA', B.NOME AS 'NOMEPESSOA', C.CHAPA AS 'CHAPA', D.CODPERFIL FROM GUSUARIO AS A WITH(NOLOCK) INNER JOIN PPESSOA AS B WITH (NOLOCK) ON B.CODUSUARIO = A.CODUSUARIO INNER JOIN PFUNC AS C WITH(NOLOCK) ON  C.CODCOLIGADA = 1 AND C.CODPESSOA = B.CODIGO AND ((C.CODSITUACAO != 'D' AND 0=(SELECT COUNT(*) FROM GCONSIST Z WHERE Z.CODTABELA='CTJEVAL003' AND Z.CODCLIENTE=C.CODPESSOA)) OR (1=(SELECT COUNT(*) FROM GCONSIST Z WHERE Z.CODTABELA='CTJEVAL003' AND Z.CODCLIENTE=C.CODPESSOA))) INNER JOIN GUSRPERFIL AS D WITH (NOLOCK) ON D.CODUSUARIO=A.CODUSUARIO AND D.CODSISTEMA='V' AND LEFT(D.CODPERFIL, 5)='CTJE.' WHERE A.CODUSUARIOREDE = @Codigo";
            return Db.Database.SqlQuery<AuthUser>(sql, new SqlParameter("@Codigo", codigo)).FirstOrDefault();
        }
    }
}
