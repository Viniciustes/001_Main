using System;

namespace CTJEvaluation001.Domain.Entities
{
    public class Annotation
    {
        public int PersonId { get; set; }
        public int Nro { get; set; }
        public int AnnotationTypeId { get; set; }
        public string AnnotationDescription { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public string Codusuario { get; set; }
    }
}
