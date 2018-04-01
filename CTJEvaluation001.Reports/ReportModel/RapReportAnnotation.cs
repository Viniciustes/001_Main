using System;
using System.ComponentModel.DataAnnotations;

namespace CTJEvaluation001.Reports.ReportModel
{
    public class RapReportAnnotation
    {
        [Key] 
        public int NroAnotacao { get; set; }
        public string Texto { get; set; }
        public DateTime DtAnotacao { get; set; }
        public DateTime? DtResolucao { get; set; }
    }
}