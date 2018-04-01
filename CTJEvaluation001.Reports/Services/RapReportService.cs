using System.Collections.Generic;
using CTJEvaluation001.Reports.ReportModel;
using CTJEvaluation001.Reports.Interfaces.Services;

namespace CTJEvaluation001.Reports.Services
{
    public class RapReportService : IRapReportService
    {
        private readonly IRapReportService _iRapReportService;

        public RapReportService(IRapReportService iRapReportService)
        {
            _iRapReportService = iRapReportService;
        }

        public RapReport GetRap(string chapa, int ano)
        {
            RapReport rapReport = new RapReport();

            rapReport.GeneralMeetings = GetGeneralMeetings(chapa, ano);
            rapReport.MeetingsWithSupervisors = GetMeetingsWithSupervisors(chapa, ano);
            rapReport.BranchSupervisors = GetBranchSupervisors(chapa, ano);
            rapReport.MiniCourses = GetMiniCourses(chapa, ano);
            rapReport.TreinamentosOptativos = GetTreinamentosOptativos(chapa, ano);
            rapReport.EdTechTrainning = GetEdTechTrainning(chapa, ano);
            rapReport.MeetingsDuringTheYear = GetMeetingsDuringTheYear(chapa, ano);
            rapReport.FaltasNaoJustificadas = GetFaltasNaoJustificadas(chapa, ano);
            rapReport.FaltasJustificadas = GetFaltasJustificadas(chapa, ano);
            rapReport.SubstituteColleagues = GetSubstituteColleagues(chapa, ano);
            rapReport.GiveEmergencyHelp = GetGiveEmergencyHelp(chapa, ano);
            rapReport.GiveMakeUpTests = GetGiveMakeUpTests(chapa, ano);
            rapReport.Others = GetOthers(chapa, ano);
            rapReport.GradeSheets = GetGradeSheets(chapa, ano);
            rapReport.Atrasos = GetAtrasos(chapa, ano);
            rapReport.TestsDate = GetTestsDate(chapa, ano);
            rapReport.Faltas = GetFaltas(chapa, ano);

            return rapReport;
        }

        public IEnumerable<RapReportAnnotation> GetAtrasos(string chapa, int ano)
        {
            return _iRapReportService.GetAtrasos(chapa, ano);
        }

        public IEnumerable<RapReportClass> GetBranchSupervisors(string chapa, int ano)
        {
            return _iRapReportService.GetBranchSupervisors(chapa, ano);
        }

        public IEnumerable<RapReportClass> GetEdTechTrainning(string chapa, int ano)
        {
            return _iRapReportService.GetEdTechTrainning(chapa, ano);
        }

        public IEnumerable<RapReportFalta> GetFaltas(string chapa, int ano)
        {
            return _iRapReportService.GetFaltas(chapa, ano);
        }

        public IEnumerable<RapReportAnnotation> GetFaltasJustificadas(string chapa, int ano)
        {
            return _iRapReportService.GetFaltasJustificadas(chapa, ano);
        }

        public IEnumerable<RapReportClass> GetFaltasNaoJustificadas(string chapa, int ano)
        {
            return _iRapReportService.GetFaltasNaoJustificadas(chapa, ano);
        }

        public IEnumerable<RapReportClass> GetGeneralMeetings(string chapa, int ano)
        {
            return _iRapReportService.GetGeneralMeetings(chapa, ano);
        }

        public IEnumerable<RapReportAnnotation> GetGiveEmergencyHelp(string chapa, int ano)
        {
            return _iRapReportService.GetGiveEmergencyHelp(chapa, ano);
        }

        public IEnumerable<RapReportAnnotation> GetGiveMakeUpTests(string chapa, int ano)
        {
            return _iRapReportService.GetGiveMakeUpTests(chapa, ano);
        }

        public IEnumerable<RapReportAnnotation> GetGradeSheets(string chapa, int ano)
        {
            return _iRapReportService.GetGradeSheets(chapa, ano);
        }

        public IEnumerable<RapReportClass> GetMeetingsDuringTheYear(string chapa, int ano)
        {
            return _iRapReportService.GetMeetingsDuringTheYear(chapa, ano);
        }

        public IEnumerable<RapReportClass> GetMeetingsWithSupervisors(string chapa, int ano)
        {
            return _iRapReportService.GetMeetingsWithSupervisors(chapa, ano);
        }

        public IEnumerable<RapReportClass> GetMiniCourses(string chapa, int ano)
        {
            return _iRapReportService.GetMiniCourses(chapa, ano);
        }

        public IEnumerable<RapReportAnnotation> GetOthers(string chapa, int ano)
        {
            return _iRapReportService.GetOthers(chapa, ano);
        }

        public IEnumerable<RapReportAnnotation> GetSubstituteColleagues(string chapa, int ano)
        {
            return _iRapReportService.GetSubstituteColleagues(chapa, ano);
        }

        public IEnumerable<RapReportAnnotation> GetTestsDate(string chapa, int ano)
        {
            return _iRapReportService.GetTestsDate(chapa, ano);
        }

        public IEnumerable<RapReportClass> GetTreinamentosOptativos(string chapa, int ano)
        {
            return _iRapReportService.GetTreinamentosOptativos(chapa, ano);
        }
    }
}
