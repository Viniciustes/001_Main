using System;

namespace CTJEvaluation001.MVC.ViewModels.Reports
{
    public class RapReportAnnotationViewModel
    {
        public int NroAnotacao { get; set; }
        public string Texto { get; set; }
        public DateTime DtAnotacao { get; set; }
        public DateTime? DtResolucao { get; set; }
    }
}