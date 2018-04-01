using CTJEvaluation001.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class AnnotationConfiguration : EntityTypeConfiguration<Annotation>
    {
        public AnnotationConfiguration()
        {
            HasKey(x => x.PersonId);
            HasKey(x => x.Nro);
        }
    }
}