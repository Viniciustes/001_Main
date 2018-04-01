using CTJEvaluation001.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class PerformanceConfiguration : EntityTypeConfiguration<Performance>
    {
        public PerformanceConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}
