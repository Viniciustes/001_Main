using CTJEvaluation001.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class CompetenceConfiguration : EntityTypeConfiguration<Competence>
    {
        public CompetenceConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}
