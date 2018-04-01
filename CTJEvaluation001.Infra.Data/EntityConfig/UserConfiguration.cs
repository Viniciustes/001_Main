using CTJEvaluation001.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("GUSUARIO");
            HasKey(x => x.Codigo)
                .Property(x => x.Codigo)
                .HasColumnName("CODUSUARIO");

        }
    }
}
