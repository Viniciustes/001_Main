using System.Web;

namespace CTJEvaluation001.Infra.CrossCutting.Interfaces
{
    public interface IFileSystem
    {
        void Save(HttpPostedFileBase file, string filename);
        void Delete(string fullname);
    }
}
