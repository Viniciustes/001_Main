using System.ComponentModel.DataAnnotations;

namespace CTJEvaluation001.Reports.ReportModel
{
    public class RapReportFalta
    {
        [Key] 
        public string Descricao { get; set; }
        public int MesComp { get; set; }
        public int? Dias { get; set; }
        public int? Horas { get; set; }
    }
}