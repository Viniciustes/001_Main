using CTJEvaluation001.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class TeacherObservationReportConfiguration : EntityTypeConfiguration<TeacherObservationReport>
    {
        public TeacherObservationReportConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}
