using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Entities.Auth;
using CTJEvaluation001.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System;

namespace CTJEvaluation001.Infra.Data.Repositories
{
    public class ObservationRepository : RepositoryBase<Observation>, IObservationRepository
    {
        public IEnumerable<Observation> GetAll(AuthUser authUser, int contextoAno)
        {
            return Db.Database.SqlQuery<Observation>("EXECUTE [Corpore].[dbo].[SPU_GETALLOBSERVATIONSBYOBSERVED] @CHAPA, @CONTEXTOANO", new object[] { new SqlParameter("@CHAPA", authUser.Chapa), new SqlParameter("@CONTEXTOANO", contextoAno) }).ToList();
        }

        public IEnumerable<Observation> GetAllByObserver(AuthUser authUser, int contextoAno)
        {
            return Db.Database.SqlQuery<Observation>("EXECUTE [Corpore].[dbo].[SPU_GETALLOBSERVATIONSBYOBSERVER] @CHAPA, @CONTEXTOANO", new object[] { new SqlParameter("@CHAPA", authUser.Chapa), new SqlParameter("@CONTEXTOANO", contextoAno) }).ToList();
        }

        public Observation GetById(AuthUser authUser, string id)
        {
            return Db.Observations.SqlQuery("SELECT 1 AS 'STATUS', A.CODAVALIACAO AS 'ID' , A.NOME AS 'NAME' , B.CHAPAAVALIADOR AS 'OBSERVERID', B.CHAPAAVALIADO AS 'OBSERVEDID', A.CODAVALIACAO AS 'CODAVALIACAO' FROM  VADAVALIACAO A WITH(NOLOCK) INNER JOIN VADPARTICIPANTES B WITH(NOLOCK) ON  B.CODCOLIGADA = A.CODCOLIGADA AND B.CODAVALIACAO = A.CODAVALIACAO AND B.CHAPAAVALIADO = @Chapa INNER JOIN PFUNC C WITH(NOLOCK) ON  C.CODCOLIGADA = 1 AND C.CHAPA = B.CHAPAAVALIADOR AND A.CODAVALIACAO+B.CHAPAAVALIADOR=@id ORDER BY A.CODAVALIACAO", new object[] { new SqlParameter("@Chapa", authUser.Chapa), new SqlParameter("@id", id) }).First();
        }

        public Observation GetByIdObserver(AuthUser authUser, string id)
        {
            return Db.Observations.SqlQuery("EXECUTE [Corpore].[dbo].[SPU_GETOBSERVATIONBYOBSERVERANDID] @CHAPA, @ID", new object[] { new SqlParameter("@CHAPA", authUser.Chapa), new SqlParameter("@ID", id) }).FirstOrDefault();
        }

        public Observed GetObserved(string id)
        {
            return Db.Observed.SqlQuery("SELECT A.CHAPA AS 'OBSERVEDID', A.NOME AS 'NAME' FROM PFUNC A (NOLOCK)WHERE A.CODCOLIGADA = 1 AND A.CHAPA = @id", new SqlParameter("@id", id)).FirstOrDefault();
        }

        public Observer GetObserver(string id)
        {
            return Db.Observer.SqlQuery("SELECT A.CHAPA AS 'OBSERVERID', A.NOME AS 'NAME' FROM PFUNC A (NOLOCK)WHERE A.CODCOLIGADA = 1 AND A.CHAPA = @id", new SqlParameter("@id", id)).FirstOrDefault();
        }

        public TeacherObservationReport GetTeacherObservationReport(string codAvaliacao, string observedId, string observerId)
        {
            return Db.TeacherObservationReport.SqlQuery("EXECUTE [Corpore].[dbo].[SPU_GETTEACHEROBSERVATIONREPORT] @ID, @OBSERVEDID, @OBSERVERID", new object[] { new SqlParameter("@observedId", observedId), new SqlParameter("@id", codAvaliacao), new SqlParameter("@observerId", observerId) }).FirstOrDefault();
        }

        public IEnumerable<FinalComments> GetFinalComments(string codAvaliacao, string observedId, string observerId)
        {
            return Db.FinalComments.SqlQuery("EXECUTE [Corpore].[dbo].[SPU_OBSERVATION_GET_FINALCOMMENTS] @ID, @OBSERVEDID, @OBSERVERID", new object[] { new SqlParameter("@observedId", observedId), new SqlParameter("@id", codAvaliacao), new SqlParameter("@observerId", observerId) }).ToList();
        }

        public IEnumerable<Competence> GetCompetences(string codAvaliacao)
        {
            return Db.Competences.SqlQuery("EXECUTE [dbo].[SPU_OBSERVATION_GET_COMPETENCES] @CODAVALIACAO", new object[] { new SqlParameter("@CODAVALIACAO", codAvaliacao) }).ToList();
        }

        public IEnumerable<Performance> GetPerformances(string codAvaliacao, string observedId, string observerId, string competenceId)
        {
            return Db.Performances.SqlQuery("EXECUTE [Corpore].[dbo].[SPU_OBSERVATION_GETPERFORMANCES] @ID, @OBSERVEDID, @OBSERVERID, @COMPETENCEID", new object[] { new SqlParameter("@observedId", observedId), new SqlParameter("@id", codAvaliacao), new SqlParameter("@observerId", observerId), new SqlParameter("@competenceId", competenceId) }).ToList();
        }

        public ObservationSave Save(AuthUser authUser, ObservationSave observation)
        {
            var paramsList = new List<SqlParameter>
            {
                new SqlParameter("@CODAVALIACAO", observation.CodAvaliacao),
                new SqlParameter("@CHAPAAVALIADOR", observation.ChapaAvaliador),
                new SqlParameter("@CHAPAAVALIADO", observation.ChapaAvaliado),
                new SqlParameter("@TEACHEROBSERVATIONREPORT", "Date: " + observation.Date + " Time: " + observation.Time + " Branch: " + observation.Branch + " Class: " + observation.Class + " Number of SS: " + observation.SS),
                new SqlParameter("@A1", observation.A1!=null ? int.Parse(observation.A1) : -1),
                new SqlParameter("@A2", observation.A2!=null ? int.Parse(observation.A2) : -1),
                new SqlParameter("@A3", observation.A3!=null ? int.Parse(observation.A3) : -1),
                new SqlParameter("@A4", observation.A4!=null ? int.Parse(observation.A4) : -1),
                new SqlParameter("@A5", observation.A5!=null ? int.Parse(observation.A5) : -1),
                new SqlParameter("@A6", observation.A6!=null ? int.Parse(observation.A6) : -1),
                new SqlParameter("@B1", observation.B1!=null ? int.Parse(observation.B1) : -1),
                new SqlParameter("@B2", observation.B2!=null ? int.Parse(observation.B2) : -1),
                new SqlParameter("@B3", observation.B3!=null ? int.Parse(observation.B3) : -1),
                new SqlParameter("@B4", observation.B4!=null ? int.Parse(observation.B4) : -1),
                new SqlParameter("@B5", observation.B5!=null ? int.Parse(observation.B5) : -1),
                new SqlParameter("@B6", observation.B6!=null ? int.Parse(observation.B6) : -1),
                new SqlParameter("@B7", observation.B7!=null ? int.Parse(observation.B7) : -1),
                new SqlParameter("@C1", observation.C1!=null ? int.Parse(observation.C1) : -1),
                new SqlParameter("@C2", observation.C2!=null ? int.Parse(observation.C2) : -1),
                new SqlParameter("@C3", observation.C3!=null ? int.Parse(observation.C3) : -1),
                new SqlParameter("@C4", observation.C4!=null ? int.Parse(observation.C4) : -1),
                new SqlParameter("@C5", observation.C5!=null ? int.Parse(observation.C5) : -1),
                new SqlParameter("@D1", observation.D1!=null ? int.Parse(observation.D1) : -1),
                new SqlParameter("@D2", observation.D2!=null ? int.Parse(observation.D2) : -1),
                new SqlParameter("@E1", observation.E1!=null ? int.Parse(observation.E1) : -1),
                new SqlParameter("@E2", observation.E2!=null ? int.Parse(observation.E2) : -1),
                new SqlParameter("@E3", observation.E3!=null ? int.Parse(observation.E3) : -1),
                new SqlParameter("@E4", observation.E4!=null ? int.Parse(observation.E4) : -1),
                new SqlParameter("@E5", observation.E5!=null ? int.Parse(observation.E5) : -1),
                new SqlParameter("@E6", observation.E6!=null ? int.Parse(observation.E6) : -1),
                new SqlParameter("@E7", observation.E7!=null ? int.Parse(observation.E7) : -1),
                new SqlParameter("@F1", observation.F1!=null ? int.Parse(observation.F1) : -1),
                new SqlParameter("@F2", observation.F2!=null ? int.Parse(observation.F2) : -1),
                new SqlParameter("@F3", observation.F3!=null ? int.Parse(observation.F3) : -1),
                new SqlParameter("@F4", observation.F4!=null ? int.Parse(observation.F4) : -1),
                new SqlParameter("@G1", observation.G1!=null ? int.Parse(observation.G1) : -1),
                new SqlParameter("@G2", observation.G2!=null ? int.Parse(observation.G2) : -1),
                new SqlParameter("@G3", observation.G3!=null ? int.Parse(observation.G3) : -1),
                new SqlParameter("@H1", observation.H1!=null ? int.Parse(observation.H1) : -1),
                new SqlParameter("@H2", observation.H2!=null ? int.Parse(observation.H2) : -1),
                new SqlParameter("@H3", observation.H3!=null ? int.Parse(observation.H3) : -1),
                new SqlParameter("@H4", observation.H4!=null ? int.Parse(observation.H4) : -1),
                new SqlParameter("@I1", observation.I1!=null ? int.Parse(observation.I1) : -1),
                new SqlParameter("@I2", observation.I2!=null ? int.Parse(observation.I2) : -1),
                new SqlParameter("@Z1", observation.Z1!=null ? observation.Z1 : " "),
                new SqlParameter("@Z2", observation.Z2!=null ? observation.Z2 : " ")
            };

            SqlParameter[] parameters = paramsList.ToArray();

            Db.Database.ExecuteSqlCommand("EXECUTE [dbo].[SPU_OBSERVATION_SAVE] @CODAVALIACAO,@CHAPAAVALIADOR,@CHAPAAVALIADO,@TEACHEROBSERVATIONREPORT,@A1,@A2,@A3,@A4,@A5,@A6,@B1,@B2,@B3,@B4,@B5,@B6,@B7,@C1,@C2,@C3,@C4,@C5,@D1,@D2,@E1,@E2,@E3,@E4,@E5,@E6,@E7,@F1,@F2,@F3,@F4,@G1,@G2,@G3,@H1,@H2,@H3,@H4,@I1,@I2, @Z1, @Z2", parameters);
            return observation;
        }

        public ObservationSaveFinal SaveF(AuthUser authUser, ObservationSaveFinal observation)
        {
            var paramsList = new List<SqlParameter>
            {
                new SqlParameter("@CODAVALIACAO", observation.CodAvaliacao),
                new SqlParameter("@CHAPAAVALIADOR", observation.ChapaAvaliador),
                new SqlParameter("@CHAPAAVALIADO", observation.ChapaAvaliado),
                new SqlParameter("@A1", observation.A1!=null ? int.Parse(observation.A1) : -1),
                new SqlParameter("@B2", observation.B2!=null ? int.Parse(observation.B2) : -1),
                new SqlParameter("@C3", observation.C3!=null ? int.Parse(observation.C3) : -1),
                new SqlParameter("@D4", observation.D4!=null ? int.Parse(observation.D4) : -1),
                new SqlParameter("@E5", observation.E5!=null ? int.Parse(observation.E5) : -1),
                new SqlParameter("@F6", observation.F6!=null ? int.Parse(observation.F6) : -1),
                new SqlParameter("@G1", observation.G1!=null ? int.Parse(observation.G1) : -1),
                new SqlParameter("@G2", observation.G2!=null ? int.Parse(observation.G2) : -1),
                new SqlParameter("@G3", observation.G3!=null ? int.Parse(observation.G3) : -1),
                new SqlParameter("@G41", observation.G41!=null ? int.Parse(observation.G41) : -1),
                new SqlParameter("@G42", observation.G42!=null ? int.Parse(observation.G42) : -1),
                new SqlParameter("@G5", observation.G5!=null ? int.Parse(observation.G5) : -1),
                new SqlParameter("@G6", observation.G6!=null ? int.Parse(observation.G6) : -1),
                new SqlParameter("@G7", observation.G7!=null ? int.Parse(observation.G7) : -1),
                new SqlParameter("@H1", observation.H1!=null ? observation.H1 : ""),
                new SqlParameter("@H2", observation.H2!=null ? observation.H2 : ""),
                new SqlParameter("@H3", observation.H3!=null ? observation.H3 : ""),
                new SqlParameter("@H4", observation.H4!=null ? observation.H4 : ""),
                new SqlParameter("@H5", observation.H5!=null ? observation.H5 : ""),
                new SqlParameter("@H6", observation.H6!=null ? observation.H6 : ""),
                new SqlParameter("@H7", observation.H7!=null ? observation.H7 : ""),
                new SqlParameter("@H8", observation.H8!=null ? observation.H8 : ""),
                new SqlParameter("@Z1", observation.Z1!=null ? observation.Z1 : "")
            };

            SqlParameter[] parameters = paramsList.ToArray();

            Db.Database.ExecuteSqlCommand("EXECUTE [dbo].[SPU_OBSERVATION_FINAL_SAVE] @CODAVALIACAO,@CHAPAAVALIADOR,@CHAPAAVALIADO,@A1,@B2,@C3,@D4,@E5,@F6,@G1,@G2,@G3,@G41,@G42,@G5,@G6,@G7,@H1,@H2,@H3,@H4,@H5,@H6,@H7,@H8,@Z1", parameters);
            return observation;
        }

        public ObservationSave Done(AuthUser authUser, ObservationSave observation)
        {
            var paramsList = new List<SqlParameter>
            {
                new SqlParameter("@CODAVALIACAO", observation.CodAvaliacao),
                new SqlParameter("@OBSERVERID", authUser.Chapa),
                new SqlParameter("@OBSERVEDID", observation.ChapaAvaliado)
            };

            SqlParameter[] parameters = paramsList.ToArray();

            Db.Database.ExecuteSqlCommand("EXECUTE [dbo].[SPU_OBSERVATION_FINALIZAR] @CODAVALIACAO, @OBSERVERID, @OBSERVEDID", parameters);
            return observation;
        }

        public ObservationSaveFinal DoneF(AuthUser authUser, ObservationSaveFinal observation)
        {
            var paramsList = new List<SqlParameter>
            {
                new SqlParameter("@CODAVALIACAO", observation.CodAvaliacao),
                new SqlParameter("@OBSERVERID", authUser.Chapa),
                new SqlParameter("@OBSERVEDID", observation.ChapaAvaliado)
            };

            SqlParameter[] parameters = paramsList.ToArray();

            Db.Database.ExecuteSqlCommand("EXECUTE [dbo].[SPU_OBSERVATION_FINALIZAR] @CODAVALIACAO, @OBSERVERID, @OBSERVEDID", parameters);
            return observation;
        }

        public IEnumerable<Escala> GetEscalaByAvaliacao(string id)
        {
            return Db.Escalas.SqlQuery("SELECT CONVERT(INT, A.VALOR) AS 'ID', A.DESCRICAO AS 'NAME' FROM VADESCALA A WHERE A.CODCOLIGADA=1 AND A.CODAVALIACAO=@CodAvaliacao", new object[] { new SqlParameter("@CodAvaliacao", id) }).ToList();
        }

        public ObservationDashboardDraw GetObservationDashboardDraw(AuthUser authUser, int contextoAno)
        {
            return Db.Database.SqlQuery<ObservationDashboardDraw>("EXECUTE [Corpore].[dbo].[SPU_OBSERVER_DASHBOARD] @CHAPA_AVALIADOR, @CONTEXTOANO", new object[] { new SqlParameter("@CHAPA_AVALIADOR", authUser.Chapa), new SqlParameter("@CONTEXTOANO", contextoAno) }).FirstOrDefault();
        }
    }
}
