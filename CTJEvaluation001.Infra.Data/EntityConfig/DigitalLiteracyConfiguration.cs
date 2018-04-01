using CTJEvaluation001.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class DigitalLiteracyConfiguration : EntityTypeConfiguration<DigitalLiteracy>
    {
        public DigitalLiteracyConfiguration()
        {
            ToTable("CTJ_DIGITALLITERACY");
            HasKey(x => x.Ano).HasKey(x => x.Chapa).HasKey(x => x.Nseq);
            Property(x => x.Data).HasColumnType("DATETIME");
        }
    }
}
