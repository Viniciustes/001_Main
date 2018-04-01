using CTJEvaluation001.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}
