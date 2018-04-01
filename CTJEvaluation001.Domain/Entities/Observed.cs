using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Entities
{
    public class Observed
    {
        public string ObservedId { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Observation> Observations { get; set; }
    }
}
