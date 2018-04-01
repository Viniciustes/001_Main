using System;

namespace CTJEvaluation001.MVC.ViewModels
{
    public class AnnotationSaveViewModel
    {
        public int Nro { get; set; }
        public int AnnotationTypeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public string Content { get; set; }
        public string Chapa { get; set; }
        public int PersonId { get; set; }
    }
}