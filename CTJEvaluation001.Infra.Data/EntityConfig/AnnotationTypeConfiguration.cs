using CTJEvaluation001.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class AnnotationTypeConfiguration : EntityTypeConfiguration<AnnotationType>
    {
        public AnnotationTypeConfiguration()
        {
            HasKey(x => x.Id);            
        }
    }
}
