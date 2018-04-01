using CTJEvaluation001.Domain.Entities.Auth;
using System.Data.Entity.ModelConfiguration;

namespace CTJEvaluation001.Infra.Data.EntityConfig.Auth
{
    public class AuthUserConfiguration : EntityTypeConfiguration<AuthUser>
    {
        public AuthUserConfiguration()
        {
            HasKey(x => x.CodUsuario);
            Ignore(x => x.ContextoAno);
        }
    }
}
