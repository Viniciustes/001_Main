using CTJEvaluation001.Infra.CrossCutting.Interfaces;
using System.Web;
using System.IO;

namespace CTJEvaluation001.Infra.CrossCutting.Services
{
    public class FileSystem : IFileSystem
    {
        public void Save(HttpPostedFileBase file, string filename)
        {
            file.SaveAs(filename);
        }

        public void Delete(string file)
        {
            if (Directory.Exists(Path.GetDirectoryName(file)))
            {
                File.Delete(@file);
            }
        }
    }
}
