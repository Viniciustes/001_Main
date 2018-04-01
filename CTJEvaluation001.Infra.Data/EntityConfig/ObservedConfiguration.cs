using System.Data.Entity.ModelConfiguration;
using CTJEvaluation001.Domain.Entities;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class ObservedConfiguration : EntityTypeConfiguration<Observed>
    {
        public ObservedConfiguration()
        {
            HasKey(x => x.ObservedId);
        }
    }
}