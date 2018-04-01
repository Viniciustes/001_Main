using System;

namespace CTJEvaluation001.MVC.ViewModels.Reports
{
    public class RapReportClassViewModel
    {
        public string CodTurma { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public int? Faltas { get; set; }
    }
}