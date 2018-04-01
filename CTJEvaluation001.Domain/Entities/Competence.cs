using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Entities
{
    public class Competence
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Concept { get; set; }
        public IEnumerable<Performance> Performances { get; set; }
    }
}
