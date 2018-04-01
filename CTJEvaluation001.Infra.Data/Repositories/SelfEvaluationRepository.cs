
using System.Collections.Generic;
using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Repositories;
using System.Data.SqlClient;
using System.Linq;
using System;
using CTJEvaluation001.Domain.Entities.Auth;

namespace CTJEvaluation001.Infra.Data.Repositories
{
    public class SelfEvaluationRepository : RepositoryBase<SelfEvaluation>, ISelfEvaluationRepository
    {
        public SelfEvaluation Get(Observed observed, int contextoAno)
        {
            var sql = "SELECT CONVERT(VARCHAR(6), A.CHAPA)+CONVERT(VARCHAR(4), A.ANO) AS 'ID', B.NOME AS NAME, A.* FROM CTJ_SELFEVALUATION A (NOLOCK) INNER JOIN PFUNC B (NOLOCK) ON B.CHAPA=A.CHAPA WHERE A.ANO=@Ano AND A.CHAPA=@Chapa";
            return Db.Database.SqlQuery<SelfEvaluation>(sql, new[] { new SqlParameter("@Ano", contextoAno), new SqlParameter("@Chapa", observed.ObservedId) }).FirstOrDefault();
        }

        public SelfEvaluation GenerateByYear(Observed observed, int contextoAno)
        {
            var sql = "INSERT INTO CTJ_SELFEVALUATION (CHAPA, ANO) VALUES(@Chapa, @Ano)";
            Db.Database.ExecuteSqlCommand(sql, new[] { new SqlParameter("@Chapa", observed.ObservedId), new SqlParameter("@Ano", contextoAno) });

            return Get(observed, contextoAno);
        }

        public IEnumerable<ProfessionalDevelopment> GetProfessionalDevelopmentByAnoAndChapa(Observed observed, int contextoAno)
        {
            List<ProfessionalDevelopment> itens = new List<ProfessionalDevelopment>();

            var sql = "SELECT A.CHAPA, A.ANO, A.TIPO, A.NSEQ, A.DATA, A.DESCRIPTION, A.DETAILS, A.IMAGEMID FROM CTJ_PROFESSIONALDEVELOPMENT A (NOLOCK) WHERE A.ANO=@Ano AND A.CHAPA=@Chapa";
            return Db.Database.SqlQuery<ProfessionalDevelopment>(sql, new[] { new SqlParameter("@Ano", contextoAno), new SqlParameter("@Chapa", observed.ObservedId) }).ToList();
        }

        public IEnumerable<DigitalLiteracy> GetDigitalLiteracyByAnoAndChapa(Observed observed, int contextoAno)
        {
            var sql = "SELECT A.* FROM CTJ_DIGITALLITERACY A (NOLOCK) WHERE A.ANO=@Ano AND A.CHAPA=@Chapa";
            return Db.DigitalLiteracies.SqlQuery(sql, new[] { new SqlParameter("@Ano", contextoAno), new SqlParameter("@Chapa", observed.ObservedId) }).ToList();
        }

        public IEnumerable<ProjectActivity> GetProjectActivityByAnoAndChapa(Observed observed, int contextoAno)
        {
            var sql = "SELECT @Ano AS 'ANO', B.CHAPA, A.CODCLIENTE AS 'CTJEVALID', A.DESCRICAO AS 'CTJEVALNAME', C.DETAILS, CASE WHEN C.ANO IS NULL THEN 0 ELSE 1 END AS 'ISCHECKED' FROM GCONSIST A (NOLOCK) LEFT JOIN CTJ_SELFEVALUATION B (NOLOCK) ON B.CHAPA=@Chapa AND B.ANO=@Ano LEFT JOIN CTJ_SELFEVALUATIONPROJECTSACTIVITIES C (NOLOCK) ON C.ANO=B.ANO AND C.CHAPA=B.CHAPA	AND C.CTJEVALID=A.CODCLIENTE WHERE A.APLICACAO='V' AND A.CODTABELA='CTJEVAL001'";
            return Db.Database.SqlQuery<ProjectActivity>(sql, new[] { new SqlParameter("@Ano", contextoAno), new SqlParameter("@Chapa", observed.ObservedId) }).ToList();

        }

        public IEnumerable<Course> GetCourseParticipated(int[] coursesList, Observed observed, int contextoAno)
        {
            IList<Course> courses = new List<Course>();

            for (int i = 0; i < coursesList.Length; i++)
            {
                var sql = "SELECT DISTINCT A.CODCURSO AS 'ID',	A.NOMECURSO AS 'NAME' FROM VCURSOS A (NOLOCK) JOIN VTURMAS B (NOLOCK) ON B.CODCOLIGADA=A.CODCOLIGADA AND B.CODCURSO=A.CODCURSO AND YEAR(B.DTINICIO)=@ContextoAno JOIN VTURMA C (NOLOCK) ON C.CODCOLIGADA=B.CODCOLIGADA AND C.CODTURMA=B.CODTURMA JOIN PFUNC D (NOLOCK) ON D.CODCOLIGADA=C.CODCOLIGADA AND D.CODPESSOA=C.CODPESSOA WHERE A.CODCOLIGADA=1 AND A.CODCURSO=@courseId AND D.CHAPA=@Chapa";
                var c = Db.Course.SqlQuery(sql, new[] { new SqlParameter("@CourseId", coursesList[i]), new SqlParameter("@Chapa", observed.ObservedId), new SqlParameter("@ContextoAno", contextoAno) }).FirstOrDefault();
                if (c != null)
                {
                    courses.Add(c);
                }
            }

            return courses;
        }

        public IEnumerable<Class> GetClassesParticipatedByCourseId(int CourseId, Observed observed, int contextoAno)
        {
            var sql = "SELECT A.CODCURSO + B.CODTURMA AS 'ID', B.NOME AS 'NAME' FROM VCURSOS A (NOLOCK) JOIN VTURMAS B (NOLOCK) ON B.CODCOLIGADA=A.CODCOLIGADA AND B.CODCURSO=A.CODCURSO AND YEAR(B.DTINICIO)=@ContextoAno JOIN VTURMA C (NOLOCK) ON C.CODCOLIGADA=B.CODCOLIGADA AND C.CODTURMA=B.CODTURMA JOIN PFUNC D (NOLOCK) ON D.CODCOLIGADA=C.CODCOLIGADA AND D.CODPESSOA=C.CODPESSOA WHERE A.CODCOLIGADA=1 AND A.CODCURSO=@CourseId AND D.CHAPA=@Chapa AND ISNULL(C.FALTAS, 0)=0";
            return Db.Classes.SqlQuery(sql, new[] { new SqlParameter("@CourseId", CourseId), new SqlParameter("@Chapa", observed.ObservedId), new SqlParameter("@ContextoAno", contextoAno) }).ToList();
        }

        public ProfessionalDevelopment Save(ProfessionalDevelopment obj, AuthUser authUser)
        {
            obj.Ano = authUser.ContextoAno;
            obj.Chapa = authUser.Chapa;
            //obj.Nseq = GetProfessionalDevelopmentByAnoAndChapa(authUser).Where(x => x.Tipo == obj.Tipo).Max(x => x.Nseq); //TODO: ajustar objeto Observed

            if (obj.Nseq == null)
            {
                obj.Nseq = 1;
            }
            else
            {
                obj.Nseq = obj.Nseq + 1;
            }

            var sql = "INSERT INTO CTJ_PROFESSIONALDEVELOPMENT (CHAPA, ANO, NSEQ, TIPO, DATA, DESCRIPTION, DETAILS, IMAGEMID) VALUES(@Chapa, @Ano, @Nseq, @Tipo, @Data, @Description, @Details, @Imagemid)";
            int nRowInserted = Db.Database.ExecuteSqlCommand(sql, new[] { new SqlParameter("@Chapa", obj.Chapa), new SqlParameter("@Ano", obj.Ano), new SqlParameter("@Nseq", obj.Nseq), new SqlParameter("@Tipo", obj.Tipo), new SqlParameter("@Data", obj.Data), new SqlParameter("@Description", obj.Description == null ? (object)DBNull.Value : obj.Description), new SqlParameter("@Details", obj.Details ?? (object)DBNull.Value), new SqlParameter("@Imagemid", obj.ImagemId == null ? (object)DBNull.Value : obj.ImagemId) });

            return obj;
        }

        public ProfessionalDevelopment Update(ProfessionalDevelopment obj, int? Ano, int? Tipo, int? Nseq, AuthUser authUser)
        {
            obj.Chapa = authUser.Chapa;
            var sql = "UPDATE CTJ_PROFESSIONALDEVELOPMENT SET DATA=@Data, DESCRIPTION=@Description, DETAILS=@Details, IMAGEMID=@Imagemid WHERE CHAPA=@Chapa AND ANO=@Ano AND NSEQ=@Nseq AND TIPO=@Tipo";
            int nRowUpdated = Db.Database.ExecuteSqlCommand(sql, new[] { new SqlParameter("@Chapa", obj.Chapa), new SqlParameter("@Ano", Ano), new SqlParameter("@Nseq", Nseq), new SqlParameter("@Tipo", Tipo), new SqlParameter("@Data", obj.Data), new SqlParameter("@Description", obj.Description == null ? (object)DBNull.Value : obj.Description), new SqlParameter("@Details", obj.Details == null ? (object)DBNull.Value : obj.Details), new SqlParameter("@Imagemid", obj.ImagemId == null ? (object)DBNull.Value : obj.ImagemId) });

            return obj;
        }

        public DigitalLiteracy Save(DigitalLiteracy obj, AuthUser authUser)
        {
            obj.Ano = authUser.ContextoAno;
            obj.Chapa = authUser.Chapa;
            //obj.Nseq = GetDigitalLiteracyByAnoAndChapa(authUser).Count() + 1; //TODO: ajustar objeto Observed

            //obj.Nseq = GetDigitalLiteracyByAnoAndChapa(authUser).Max(x => x.Nseq); //TODO: ajustar objeto Observed

            if (obj.Nseq == null)
            {
                obj.Nseq = 1;
            }
            else
            {
                obj.Nseq = obj.Nseq + 1;
            }

            var sql = "INSERT INTO CTJ_DIGITALLITERACY (CHAPA, ANO, NSEQ, DATA, DESCRIPTION) VALUES(@Chapa, @Ano, @Nseq, @Data, @Description)";
            int nRowInserted = Db.Database.ExecuteSqlCommand(sql, new[] { new SqlParameter("@Chapa", obj.Chapa), new SqlParameter("@Ano", obj.Ano), new SqlParameter("@Nseq", obj.Nseq), new SqlParameter("@Data", obj.Data), new SqlParameter("@Description", obj.Description) });

            return obj;
        }

        public DigitalLiteracy Update(DigitalLiteracy obj, int? Ano, int? Nseq, AuthUser authUser)
        {
            obj.Chapa = authUser.Chapa;

            var sql = "UPDATE CTJ_DIGITALLITERACY SET DATA=@Data, DESCRIPTION=@Description WHERE CHAPA=@Chapa AND ANO=@Ano AND NSEQ=@Nseq;";
            int nRowUpdated = Db.Database.ExecuteSqlCommand(sql, new[] { new SqlParameter("@Chapa", obj.Chapa), new SqlParameter("@Ano", obj.Ano), new SqlParameter("@Nseq", obj.Nseq), new SqlParameter("@Data", obj.Data), new SqlParameter("@Description", obj.Description) });

            return obj;
        }

        public ProjectActivity Save(ProjectActivity obj, AuthUser authUser)
        {
            obj.Chapa = authUser.Chapa;
            obj.Ano = authUser.ContextoAno;

            var sql = "INSERT INTO CTJ_SELFEVALUATIONPROJECTSACTIVITIES (ANO, CHAPA, CTJEVALID, DETAILS) VALUES(@Ano, @Chapa, @CtjEvalId, @Details)";
            int nRowInserted = Db.Database.ExecuteSqlCommand(sql, new[] { new SqlParameter("@Ano", obj.Ano), new SqlParameter("@Chapa", obj.Chapa), new SqlParameter("@CtjEvalId", obj.CtjEvalId), new SqlParameter("@Details", obj.Details) });

            return obj;
        }

        public ProjectActivity Update(ProjectActivity obj, int Ano, string Chapa, string CtjEvalId, AuthUser authUser)
        {
            obj.Chapa = authUser.Chapa;
            obj.Ano = authUser.ContextoAno;

            var sql = "UPDATE CTJ_SELFEVALUATIONPROJECTSACTIVITIES SET DETAILS=@Details WHERE ANO=@Ano AND CHAPA=@Chapa AND CTJEVALID=@CtjEvalId";
            int nRowInserted = Db.Database.ExecuteSqlCommand(sql, new[] { new SqlParameter("@Ano", Ano), new SqlParameter("@Chapa", Chapa), new SqlParameter("@CtjEvalId", CtjEvalId), new SqlParameter("@Details", obj.Details) });

            return obj;
        }

        public ProjectActivity Remove(ProjectActivity obj, AuthUser authUser)
        {
            obj.Chapa = authUser.Chapa;
            obj.Ano = authUser.ContextoAno;

            var sql = "DELETE FROM CTJ_SELFEVALUATIONPROJECTSACTIVITIES WHERE ANO=@Ano AND CHAPA=@Chapa AND CTJEVALID=@CtjEvalId";
            int nRowDeleted = Db.Database.ExecuteSqlCommand(sql, new[] { new SqlParameter("@Ano", obj.Ano), new SqlParameter("@Chapa", obj.Chapa), new SqlParameter("@CtjEvalId", obj.CtjEvalId) });

            return obj;
        }

        public ProfessionalDevelopment Remove(ProfessionalDevelopment obj, AuthUser authUser)
        {
            obj.Chapa = authUser.Chapa;
            obj.Ano = authUser.ContextoAno;

            var sql = "DELETE FROM CTJ_PROFESSIONALDEVELOPMENT WHERE ANO=@Ano AND CHAPA=@Chapa AND TIPO=@Tipo AND NSEQ=@Nseq";
            int nRowDeleted = Db.Database.ExecuteSqlCommand(sql, new[] { new SqlParameter("@Ano", obj.Ano), new SqlParameter("@Chapa", obj.Chapa), new SqlParameter("@Tipo", obj.Tipo), new SqlParameter("@Nseq", obj.Nseq) });

            return obj;
        }

        public DigitalLiteracy Remove(DigitalLiteracy obj, AuthUser authUser)
        {
            obj.Chapa = authUser.Chapa;
            obj.Ano = authUser.ContextoAno;

            var sql = "DELETE FROM CTJ_DIGITALLITERACY WHERE ANO=@Ano AND CHAPA=@Chapa AND NSEQ=@Nseq";
            int nRowDeleted = Db.Database.ExecuteSqlCommand(sql, new[] { new SqlParameter("@Ano", obj.Ano), new SqlParameter("@Chapa", obj.Chapa), new SqlParameter("@Nseq", obj.Nseq) });

            return obj;
        }

        public SelfEvalSave Save(SelfEvalSave obj, AuthUser authUser)
        {
            var sql = "UPDATE CTJ_SELFEVALUATION SET CTJEVENTS01CONFIRM = @ctjevents01confirm, CTJEVENTS02CONFIRM = @ctjevents02confirm, CTJEVENTS02ACONFIRM = @ctjevents02aconfirm, DEGREE = @degree, CERTIFICATEOFPROFICIENCY = @certificateofproficiency, DIGITALPROJECT = @digitalproject, FINALREFLECTIONA = @finalreflectiona, FINALREFLECTIONB = @finalreflectionb, FINALREFLECTIONC = @finalreflectionc, FINALREFLECTIOND = @finalreflectiond, FINALREFLECTIONE = @finalreflectione, FINALREFLECTIONF = @finalreflectionf, FINALREFLECTIONG = @finalreflectiong WHERE CHAPA = @chapa AND ANO = @ano";

            List<SqlParameter> paramsList = new List<SqlParameter>();
            paramsList.Add(new SqlParameter("@ano", authUser.ContextoAno));
            paramsList.Add(new SqlParameter("@chapa", authUser.Chapa));
            paramsList.Add(new SqlParameter("@ctjevents01confirm", obj.Ctjevents01confirm));
            paramsList.Add(new SqlParameter("@ctjevents02confirm", obj.Ctjevents02confirm));
            paramsList.Add(new SqlParameter("@ctjevents02aconfirm", obj.CtjEvents02AConfirm));
            paramsList.Add(new SqlParameter("@degree", obj.Degree));
            paramsList.Add(new SqlParameter("@certificateofproficiency", obj.CertificateOfProficiency));
            paramsList.Add(new SqlParameter("@digitalproject", obj.DigitalProject ?? (object)DBNull.Value));
            paramsList.Add(new SqlParameter("@finalreflectiona", obj.FinalReflectionA ?? (object)DBNull.Value));
            paramsList.Add(new SqlParameter("@finalreflectionb", obj.FinalReflectionB ?? (object)DBNull.Value));
            paramsList.Add(new SqlParameter("@finalreflectionc", obj.FinalReflectionC ?? (object)DBNull.Value));
            paramsList.Add(new SqlParameter("@finalreflectiond", obj.FinalReflectionD ?? (object)DBNull.Value));
            paramsList.Add(new SqlParameter("@finalreflectione", obj.FinalReflectionE ?? (object)DBNull.Value));
            paramsList.Add(new SqlParameter("@finalreflectionf", obj.FinalReflectionF ?? (object)DBNull.Value));
            paramsList.Add(new SqlParameter("@finalreflectiong", obj.FinalReflectionG ?? (object)DBNull.Value));
            SqlParameter[] parameters = paramsList.ToArray();

            int nRowInserted = Db.Database.ExecuteSqlCommand(sql, parameters);

            return obj;
        }

        public IEnumerable<SelfEvaluation> GetAllByObserver(Observer observer, int contextoAno)
        {
            var procedure = "EXECUTE [dbo].[SPU_GETALLBYOBSERVER] @CHAPAOBSERVER, @CONTEXTOANO";

            return Db.SelfEvaluation.SqlQuery(procedure, new[] { new SqlParameter("@CHAPAOBSERVER", observer.ObserverId), new SqlParameter("@CONTEXTOANO", contextoAno) }).ToList();
        }
    }
}