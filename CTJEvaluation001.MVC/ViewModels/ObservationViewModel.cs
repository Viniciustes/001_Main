using CTJEvaluation001.Domain.Entities;
using System.Collections.Generic;

namespace CTJEvaluation001.MVC.ViewModels
{
    public class ObservationViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ObserverId { get; set; }
        public Observer Observer { get; set; }
        public string ObservedId { get; set; }
        public Observed Observed { get; set; }
        public IEnumerable<Competence> Competences { get; set; }
        public TeacherObservationReport TeacherObservationReport { get; set; }
        public IEnumerable<FinalComments> FinalComments { get; set; }
        public IEnumerable<Escala> Escalas { get; set; }
        public int? Status { get; set; }
        public string CodAvaliacao { get; set; }
    }
}