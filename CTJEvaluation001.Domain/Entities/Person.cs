using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string GrauInstrucao { get; set; }
        public IEnumerable<Annotation> Annotations { get; set; }
    }
}