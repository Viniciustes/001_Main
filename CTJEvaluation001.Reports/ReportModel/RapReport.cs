using System.Collections.Generic;

namespace CTJEvaluation001.Reports.ReportModel
{
    public class RapReport
    {
        public IEnumerable<RapReportClass> GeneralMeetings { get; set; }
        public IEnumerable<RapReportClass> MeetingsWithSupervisors { get; set; }
        public IEnumerable<RapReportClass> BranchSupervisors { get; set; }
        public IEnumerable<RapReportClass> MiniCourses { get; set; }
        public IEnumerable<RapReportClass> TreinamentosOptativos { get; set; }
        public IEnumerable<RapReportClass> EdTechTrainning { get; set; }
        public IEnumerable<RapReportClass> MeetingsDuringTheYear { get; set; }
        public IEnumerable<RapReportClass> FaltasNaoJustificadas { get; set; }
        public IEnumerable<RapReportAnnotation> FaltasJustificadas { get; set; }
        public IEnumerable<RapReportAnnotation> SubstituteColleagues { get; set; }
        public IEnumerable<RapReportAnnotation> GiveEmergencyHelp { get; set; }
        public IEnumerable<RapReportAnnotation> GiveMakeUpTests { get; set; }
        public IEnumerable<RapReportAnnotation> Others { get; set; }
        public IEnumerable<RapReportAnnotation> GradeSheets { get; set; }
        public IEnumerable<RapReportAnnotation> Atrasos { get; set; }
        public IEnumerable<RapReportAnnotation> TestsDate { get; set; }
        public IEnumerable<RapReportFalta> Faltas { get; set; }
    }
}