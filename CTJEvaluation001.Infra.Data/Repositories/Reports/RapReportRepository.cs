
using System;
using System.Collections.Generic;
using CTJEvaluation001.Reports.Interfaces.Repositories;
using CTJEvaluation001.Reports.ReportModel;
using System.Data.SqlClient;
using CTJEvaluation001.Infra.Data.Context;
using System.Linq;

namespace CTJEvaluation001.Infra.Data.Repositories.Reports
{
    public class RapReportRepository : IRapReportRepository
    {
        protected CTJEvaluation001Context Db = new CTJEvaluation001Context();

        public IEnumerable<RapReportAnnotation> GetAtrasos(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETATRASOS] @Chapa, @Ano";

            return Db.RapReportAnnotations.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportClass> GetBranchSupervisors(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETBRANCHSUPERVISORS] @Chapa, @Ano";

            return Db.RapReportClasss.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportClass> GetEdTechTrainning(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETEDTECHTRAINNING] @Chapa, @Ano";

            return Db.RapReportClasss.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportFalta> GetFaltas(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETFALTAS] @Chapa, @Ano";

            return Db.RapReportFaltas.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportAnnotation> GetFaltasJustificadas(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETFALTASJUSTIFICADAS] @Chapa, @Ano";

            return Db.RapReportAnnotations.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportClass> GetFaltasNaoJustificadas(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETFALTASNAOJUSTIFICADAS] @Chapa, @Ano";

            return Db.RapReportClasss.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportClass> GetGeneralMeetings(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETGENERALMEETINGS] @Chapa, @Ano";

            return Db.RapReportClasss.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportAnnotation> GetGiveEmergencyHelp(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETGIVEEMERGENCYHELP] @Chapa, @Ano";

            return Db.RapReportAnnotations.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportAnnotation> GetGiveMakeUpTests(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETGIVEMAKEUPTESTS] @Chapa, @Ano";

            return Db.RapReportAnnotations.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportAnnotation> GetGradeSheets(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETGRADESHEETS] @Chapa, @Ano";

            return Db.RapReportAnnotations.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportClass> GetMeetingsDuringTheYear(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETMEETINGSDURINGTHEYEAR] @Chapa, @Ano";

            return Db.RapReportClasss.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportClass> GetMeetingsWithSupervisors(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETMEETINGSWITHSUPERVISORS] @Chapa, @Ano";

            return Db.RapReportClasss.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportClass> GetMiniCourses(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETMINICOURSES] @Chapa, @Ano";

            return Db.RapReportClasss.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportAnnotation> GetOthers(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETOTHERS] @Chapa, @Ano";

            return Db.RapReportAnnotations.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportAnnotation> GetSubstituteColleagues(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETSUBSTITUTECOLLEAGUES] @Chapa, @Ano";

            return Db.RapReportAnnotations.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportAnnotation> GetTestsDate(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETTESTSDATE] @Chapa, @Ano";

            return Db.RapReportAnnotations.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }

        public IEnumerable<RapReportClass> GetTreinamentosOptativos(string chapa, int ano)
        {
            var procedure = "EXECUTE [dbo].[SPU_RAPREPORT_GETTREINAMENTOSOPTATIVOS] @Chapa, @Ano";

            return Db.RapReportClasss.SqlQuery(procedure, new[] { new SqlParameter("@Chapa", chapa), new SqlParameter("@Ano", ano) }).ToList();
        }
    }
}
