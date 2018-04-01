using System.Data.Entity.ModelConfiguration;
using CTJEvaluation001.Domain.Entities;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class ObserverConfiguration : EntityTypeConfiguration<Observer>
    {
        public ObserverConfiguration()
        {
            HasKey(x => x.ObserverId);
        }
    }
}
