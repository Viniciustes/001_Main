using CTJEvaluation001.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class SelfEvalSaveConfiguration : EntityTypeConfiguration<SelfEvalSave>
    {
        public SelfEvalSaveConfiguration()
        {
            ToTable("CTJ_SELFEVALUATION");
            HasKey(x => x.Chapa).HasKey(x => x.Ano);
        }
    }
}

