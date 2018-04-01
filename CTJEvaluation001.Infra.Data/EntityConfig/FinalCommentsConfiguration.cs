using CTJEvaluation001.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class FinalCommentsConfiguration : EntityTypeConfiguration<FinalComments>
    {
        public FinalCommentsConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}
