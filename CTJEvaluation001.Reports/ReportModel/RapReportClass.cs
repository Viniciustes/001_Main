using System;
using System.ComponentModel.DataAnnotations;

namespace CTJEvaluation001.Reports.ReportModel
{
    public class RapReportClass
    {
        [Key] 
        public string CodTurma { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public int? Faltas { get; set; }
    }
}