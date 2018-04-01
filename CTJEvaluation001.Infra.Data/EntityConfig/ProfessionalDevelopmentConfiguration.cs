using System.Data.Entity.ModelConfiguration;
using CTJEvaluation001.Domain.Entities;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class ProfessionalDevelopmentConfiguration : EntityTypeConfiguration<ProfessionalDevelopment>
    {
        public ProfessionalDevelopmentConfiguration()
        {
            ToTable("CTJ_PROFESSIONALDEVELOPMENT");
            HasKey(x => x.Ano).HasKey(x => x.Chapa).HasKey(x => x.Tipo).HasKey(x => x.Nseq);
            Property(x => x.Description).IsOptional();
            Property(x => x.Details).IsOptional();
            Property(x => x.ImagemId).IsOptional();
            Property(x => x.Data).HasColumnType("DATETIME");
        }
    }
}
