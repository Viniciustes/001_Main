using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Repositories;

namespace CTJEvaluation001.Infra.Data.Repositories
{
    public class FileUploadRepository : RepositoryBase<FileUpload>, IFileUploadRepository
    {
        public FileUpload GetById(int? id)
        {
            return Db.FileUpload.Find(id);
        }

        public FileUpload Save(FileUpload upload)
        {
            Db.FileUpload.Add(upload);
            Db.SaveChanges();

            return upload;
        }
    }
}
