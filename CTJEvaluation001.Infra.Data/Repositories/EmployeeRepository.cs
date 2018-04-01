using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Repositories;
using System.Data.SqlClient;
using System.Linq;
using System;
using System.Collections.Generic;
using CTJEvaluation001.Domain.Entities.Auth;

namespace CTJEvaluation001.Infra.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public Annotation GetAnnotationByPersonAndNro(Person person, int nro, AuthUser authUser)
        {
            var sql = "SELECT A.CODIGO AS 'PERSONID', CONVERT(INT, C.NROANOTACAO) AS 'NRO', CONVERT(INT, C.TIPO) AS 'ANNOTATIONTYPEID', D.DESCRICAO AS 'ANNOTATIONDESCRIPTION', C.TEXTO AS 'CONTENT', C.DTANOTACAO AS 'DATE', C.DTRESOLUCAO AS 'RESOLUTIONDATE', E.CODUSUARIO FROM PPESSOA AS A WITH (NOLOCK) INNER JOIN PFUNC AS B WITH (NOLOCK) ON  B.CODCOLIGADA=1 AND B.CODPESSOA=A.CODIGO AND B.REGATUAL=1 INNER JOIN PANOTAC AS C WITH (NOLOCK) ON  C.CODPESSOA=A.CODIGO AND C.TIPO IN (SELECT Z.CODCLIENTE FROM GCONSIST Z(NOLOCK) WHERE Z.CODTABELA = 'CTJEVAL002' AND Z.DESCRICAO LIKE @Perfil) INNER JOIN PTPANOTACAO AS D WITH (NOLOCK) ON D.CODCLIENTE=C.TIPO LEFT JOIN GUSUARIO E WITH (NOLOCK) ON E.CODUSUARIO=C.RECMODIFIEDBY WHERE A.CODIGO=@Codigo AND C.NROANOTACAO=@Nro";

            return Db.Database.SqlQuery<Annotation>(sql, new[] { new SqlParameter("@Codigo", person.Id), new SqlParameter("@Nro", nro), new SqlParameter("@Perfil", "%"+authUser.Codperfil+"%") }).FirstOrDefault();
        }

        public IEnumerable<Annotation> GetAnnotationsByPerson(Person person, AuthUser authUser)
        {
            var sql = "SELECT A.CODIGO AS 'PERSONID', CONVERT(INT, C.NROANOTACAO) AS 'NRO', CONVERT(INT, C.TIPO) AS 'ANNOTATIONTYPEID', D.DESCRICAO AS 'ANNOTATIONDESCRIPTION', REPLACE(CONVERT(VARCHAR(MAX), C.TEXTO), '\"', '') AS 'CONTENT', C.DTANOTACAO AS 'DATE', C.DTRESOLUCAO AS 'RESOLUTIONDATE', E.CODUSUARIO FROM PPESSOA AS A WITH (NOLOCK) INNER JOIN PFUNC AS B WITH (NOLOCK) ON  B.CODCOLIGADA=1 AND B.CODPESSOA=A.CODIGO AND B.REGATUAL=1 INNER JOIN PANOTAC AS C WITH (NOLOCK) ON C.CODPESSOA=A.CODIGO AND C.TIPO IN (SELECT Z.CODCLIENTE FROM GCONSIST Z(NOLOCK) WHERE Z.CODTABELA = 'CTJEVAL002' AND Z.DESCRICAO LIKE @Perfil) INNER JOIN PTPANOTACAO AS D WITH (NOLOCK) ON D.CODCLIENTE=C.TIPO LEFT JOIN GUSUARIO E WITH (NOLOCK) ON E.CODUSUARIO=C.RECMODIFIEDBY WHERE A.CODIGO=@Codigo ORDER BY C.NROANOTACAO";

            return Db.Database.SqlQuery<Annotation>(sql, new[] { new SqlParameter("@Codigo", person.Id), new SqlParameter("@Perfil", "%" + authUser.Codperfil + "%") }).ToList();
        }

        public IEnumerable<Annotation> GetAllAnnotationsByPerson(Person person, AuthUser authUser)
        {
            var sql = "SELECT A.CODIGO AS 'PERSONID', CONVERT(INT, C.NROANOTACAO) AS 'NRO', CONVERT(INT, C.TIPO) AS 'ANNOTATIONTYPEID', D.DESCRICAO AS 'ANNOTATIONDESCRIPTION', C.TEXTO AS 'CONTENT', C.DTANOTACAO AS 'DATE', C.DTRESOLUCAO AS 'RESOLUTIONDATE', E.CODUSUARIO FROM PPESSOA AS A WITH (NOLOCK) INNER JOIN PFUNC AS B WITH (NOLOCK) ON  B.CODCOLIGADA=1 AND B.CODPESSOA=A.CODIGO AND B.REGATUAL=1 INNER JOIN PANOTAC AS C WITH (NOLOCK) ON C.CODPESSOA=A.CODIGO INNER JOIN PTPANOTACAO AS D WITH (NOLOCK) ON D.CODCLIENTE=C.TIPO LEFT JOIN GUSUARIO E WITH (NOLOCK) ON E.CODUSUARIO=C.RECMODIFIEDBY WHERE A.CODIGO=@Codigo ORDER BY C.NROANOTACAO";

            return Db.Database.SqlQuery<Annotation>(sql, new[] { new SqlParameter("@Codigo", person.Id) }).ToList();
        }

        public Employee GetByChapa(string chapa)
        {
            var sql = "SELECT A.CHAPA, A.NOME AS 'NAME', B.NOME AS 'ROLE', B.CODIGO AS 'ROLEID' FROM PFUNC AS A WITH(NOLOCK) INNER JOIN PPESSOA AS B WITH (NOLOCK) ON B.CODIGO = A.CODPESSOA WHERE A.CHAPA=@Chapa AND A.CODSITUACAO != 'D'";

            return Db.Database.SqlQuery<Employee>(sql, new[] { new SqlParameter("@Chapa", chapa) }).FirstOrDefault();
        }

        public IEnumerable<Employee> GetByName(string name)
        {
            var sql = "SELECT A.CHAPA, A.NOME AS 'NAME', B.NOME AS 'ROLE', B.CODIGO AS 'ROLEID' FROM PFUNC AS A WITH(NOLOCK) INNER JOIN PFUNCAO AS B WITH (NOLOCK) ON B.CODIGO = A.CODFUNCAO WHERE A.NOME LIKE @Nome AND A.CODSITUACAO != 'D'";

            return Db.Database.SqlQuery<Employee>(sql, new[] { new SqlParameter("@Nome", name + "%") }).ToList();
        }

        public IEnumerable<Employee> GetByNameAndFuncao(string name, string inFuncoes)
        {
            var sql = "SELECT A.CHAPA, A.NOME AS 'NAME', B.NOME AS 'ROLE', B.CODIGO AS 'ROLEID' FROM PFUNC AS A WITH(NOLOCK) INNER JOIN PFUNCAO AS B WITH (NOLOCK) ON B.CODIGO = A.CODFUNCAO AND B.CODIGO IN (" + inFuncoes + ") WHERE A.NOME LIKE @Nome AND A.CODSITUACAO != 'D'";

            return Db.Database.SqlQuery<Employee>(sql, new[] { new SqlParameter("@Nome", name + "%") }).ToList();
        }

        public Person GetPersonByChapa(string chapa)
        {
            var sql = "SELECT B.CODIGO AS 'ID', B.NOME AS 'NAME', B.CPF, B.GRAUINSTRUCAO FROM PFUNC A(NOLOCK) INNER JOIN PPESSOA B (NOLOCK)ON B.CODIGO = A.CODPESSOA WHERE A.CHAPA=@Chapa";
            return Db.Database.SqlQuery<Person>(sql, new[] { new SqlParameter("@Chapa", chapa) }).FirstOrDefault();
        }

        public AnnotationSave Save(AnnotationSave obj, AuthUser authUser)
        {
            var sql = "INSERT INTO PANOTAC (CODPESSOA, NROANOTACAO, TEXTO, DTANOTACAO, DTRESOLUCAO, TIPO, RECCREATEDBY, RECCREATEDON, RECMODIFIEDBY, RECMODIFIEDON) VALUES (@codpessoa, @nroanotacao, @texto, @dtanotacao, @dtresolucao, @tipo, @reccreatedby, @reccreatedon, @recmodifiedby, @recmodifiedon)";

            List<SqlParameter> paramsList = new List<SqlParameter>();
            paramsList.Add(new SqlParameter("@codpessoa", obj.PersonId));
            paramsList.Add(new SqlParameter("@nroanotacao", obj.Nro));
            paramsList.Add(new SqlParameter("@texto", obj.Content));
            paramsList.Add(new SqlParameter("@dtanotacao", obj.Date));
            paramsList.Add(new SqlParameter("@dtresolucao", obj.ResolutionDate == null ? (object)DBNull.Value : obj.ResolutionDate));
            paramsList.Add(new SqlParameter("@tipo", obj.AnnotationTypeId));
            paramsList.Add(new SqlParameter("@reccreatedby", authUser.CodUsuario));
            paramsList.Add(new SqlParameter("@reccreatedon", DateTime.Now));
            paramsList.Add(new SqlParameter("@recmodifiedby", authUser.CodUsuario));
            paramsList.Add(new SqlParameter("@recmodifiedon", DateTime.Now));
            SqlParameter[] parameters = paramsList.ToArray();

            int nRowInserted = Db.Database.ExecuteSqlCommand(sql, parameters);
            return obj;
        }

        public AnnotationSave Update(AnnotationSave obj, AuthUser authUser)
        {
            var sql = "UPDATE PANOTAC SET TEXTO=@texto, DTANOTACAO=@dtanotacao, DTRESOLUCAO=@dtresolucao, RECMODIFIEDBY=@recmodifiedby, RECMODIFIEDON=@recmodifiedon WHERE CODPESSOA=@codpessoa AND NROANOTACAO=@nroanotacao AND TIPO=@tipo";

            List<SqlParameter> paramsList = new List<SqlParameter>();
            paramsList.Add(new SqlParameter("@codpessoa", obj.PersonId));
            paramsList.Add(new SqlParameter("@nroanotacao", obj.Nro));
            paramsList.Add(new SqlParameter("@texto", obj.Content));
            paramsList.Add(new SqlParameter("@dtanotacao", obj.Date));
            paramsList.Add(new SqlParameter("@dtresolucao", obj.ResolutionDate == null ? (object) DBNull.Value : obj.ResolutionDate));
            paramsList.Add(new SqlParameter("@tipo", obj.AnnotationTypeId));
            paramsList.Add(new SqlParameter("@recmodifiedby", authUser.CodUsuario));
            paramsList.Add(new SqlParameter("@recmodifiedon", DateTime.Now));
            SqlParameter[] parameters = paramsList.ToArray();

            int nRowUpdated = Db.Database.ExecuteSqlCommand(sql, parameters);
            return obj;
        }

        public IEnumerable<Employee> GetByNameAndPerfil(string Name, string Perfil)
        {
            var sql = "SELECT A.CHAPA, A.NOME AS 'NAME', B.NOME AS 'ROLE', B.CODIGO AS 'ROLEID' FROM PFUNC AS A WITH(NOLOCK) INNER JOIN PFUNCAO AS B WITH (NOLOCK) ON B.CODIGO = A.CODFUNCAO WHERE A.NOME LIKE @Nome AND A.CODSITUACAO != 'D'";

            return Db.Database.SqlQuery<Employee>(sql, new[] { new SqlParameter("@Nome", Name + "%") }).ToList();
        }
    }
}