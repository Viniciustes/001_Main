using CTJEvaluation001.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CTJEvaluation001.Infra.Data.EntityConfig
{
    public class FileUploadConfiguration : EntityTypeConfiguration<FileUpload>
    {
        public FileUploadConfiguration()
        {
            ToTable("CTJ_UPLOADS");
            HasKey(x => x.Id);
        }
    }
}
