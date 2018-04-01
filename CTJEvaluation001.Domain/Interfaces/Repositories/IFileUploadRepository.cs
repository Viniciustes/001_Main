using CTJEvaluation001.Domain.Entities;

namespace CTJEvaluation001.Domain.Interfaces.Repositories
{
    public interface IFileUploadRepository : IRepositoryBase<FileUpload>
    {
        FileUpload Save(FileUpload upload);
        FileUpload GetById(int? id);
    }
}
