using System.Collections.Generic;

namespace CTJEvaluation001.MVC.ViewModels.Reports
{
    public class RapReportViewModel
    {
        public IEnumerable<RapReportClassViewModel> GeneralMeetings { get; set; }
        public IEnumerable<RapReportClassViewModel> MeetingsWithSupervisors { get; set; }
        public IEnumerable<RapReportClassViewModel> BranchSupervisors { get; set; }
        public IEnumerable<RapReportClassViewModel> MiniCourses { get; set; }
        public IEnumerable<RapReportClassViewModel> TreinamentosOptativos { get; set; }
        public IEnumerable<RapReportClassViewModel> EdTechTrainning { get; set; }
        public IEnumerable<RapReportClassViewModel> MeetingsDuringTheYear { get; set; }
        public IEnumerable<RapReportClassViewModel> FaltasNaoJustificadas { get; set; }
        public IEnumerable<RapReportAnnotationViewModel> FaltasJustificadas { get; set; }
        public IEnumerable<RapReportAnnotationViewModel> SubstituteColleagues { get; set; }
        public IEnumerable<RapReportAnnotationViewModel> GiveEmergencyHelp { get; set; }
        public IEnumerable<RapReportAnnotationViewModel> GiveMakeUpTests { get; set; }
        public IEnumerable<RapReportAnnotationViewModel> Others { get; set; }
        public IEnumerable<RapReportAnnotationViewModel> GradeSheets { get; set; }
        public IEnumerable<RapReportAnnotationViewModel> Atrasos { get; set; }
        public IEnumerable<RapReportAnnotationViewModel> TestsDate { get; set; }
        public IEnumerable<RapReportFaltaViewModel> Faltas { get; set; }
    }
}