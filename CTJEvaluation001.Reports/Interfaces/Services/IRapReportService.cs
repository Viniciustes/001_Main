using CTJEvaluation001.Reports.ReportModel;
using System.Collections.Generic;

namespace CTJEvaluation001.Reports.Interfaces.Services
{
    public interface IRapReportService
    {
        IEnumerable<RapReportAnnotation> GetAtrasos(string chapa, int ano);
        IEnumerable<RapReportAnnotation> GetFaltasJustificadas(string chapa, int ano);
        IEnumerable<RapReportAnnotation> GetGiveEmergencyHelp(string chapa, int ano);
        IEnumerable<RapReportAnnotation> GetGiveMakeUpTests(string chapa, int ano);
        IEnumerable<RapReportAnnotation> GetGradeSheets(string chapa, int ano);
        IEnumerable<RapReportAnnotation> GetOthers(string chapa, int ano);
        IEnumerable<RapReportAnnotation> GetSubstituteColleagues(string chapa, int ano);
        IEnumerable<RapReportAnnotation> GetTestsDate(string chapa, int ano);
        IEnumerable<RapReportClass> GetBranchSupervisors(string chapa, int ano);
        IEnumerable<RapReportClass> GetEdTechTrainning(string chapa, int ano);
        IEnumerable<RapReportClass> GetFaltasNaoJustificadas(string chapa, int ano);
        IEnumerable<RapReportClass> GetGeneralMeetings(string chapa, int ano);
        IEnumerable<RapReportClass> GetMeetingsDuringTheYear(string chapa, int ano);
        IEnumerable<RapReportClass> GetMeetingsWithSupervisors(string chapa, int ano);
        IEnumerable<RapReportClass> GetMiniCourses(string chapa, int ano);
        IEnumerable<RapReportClass> GetTreinamentosOptativos(string chapa, int ano);
        IEnumerable<RapReportFalta> GetFaltas(string chapa, int ano);
    }
}
