using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Entities.Auth;
using System.IO;
using System.Web;

namespace CTJEvaluation001.Infra.CrossCutting.Interfaces
{
    public interface IFileUploadService
    {
        string GetUserName(string codigo);
        FileUpload Upload(HttpFileCollectionBase files, AuthUser authUser);
        bool Delete(FileUpload obj);
        DirectoryInfo CreateDirectory(string directoryName);
        FileUpload SaveToDatabase(string diskBasepath, string appBasepath, string basepath, string filename, int filesize, string mime);
    }
}