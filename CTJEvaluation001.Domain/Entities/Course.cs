using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Entities
{
    public class Course
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}
