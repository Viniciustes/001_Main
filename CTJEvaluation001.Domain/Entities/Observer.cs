using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Entities
{
    public class Observer
    {
        public string ObserverId { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Observation> Observations { get; set; }
    }
}
