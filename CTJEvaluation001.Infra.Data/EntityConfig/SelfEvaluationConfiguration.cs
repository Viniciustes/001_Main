using CTJEvaluation001.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class SelfEvaluationConfiguration : EntityTypeConfiguration<SelfEvaluation>
    {
        public SelfEvaluationConfiguration()
        {
            HasKey(x => x.Id);
            Ignore(x => x.Question1);
            Ignore(x => x.Question2);
            Ignore(x => x.Question2A);
            Ignore(x => x.DegreeComplete);
        }
    }
}
