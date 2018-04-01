using System.Web;
using System.IO;
using CTJEvaluation001.Infra.CrossCutting.Interfaces;
using CTJEvaluation001.Domain.Entities;
using CTJEvaluation001.Domain.Interfaces.Repositories;
using System;
using System.Configuration;
using CTJEvaluation001.Domain.Entities.Auth;
using System.Linq;

namespace CTJEvaluation001.Infra.CrossCutting.Services
{
    public class FileUploadService : IFileUploadService
    {
        private IFileSystem _selfFileSystem;
        private IFileUploadRepository _selfFileUploadRepository;
        private IUserRepository _selfUserRepository;

        public FileUploadService(IFileSystem selfFileSystem,
            IFileUploadRepository fileUploadRepository,
            IUserRepository userRepository)
        {
            _selfFileSystem = selfFileSystem;
            _selfFileUploadRepository = fileUploadRepository;
            _selfUserRepository = userRepository;
        }

        public string GetUserName(string codigo)
        {
            return _selfUserRepository.Find(codigo).Nome;
        }

        public DirectoryInfo CreateDirectory(string directoryName)
        {
            try
            {
                return Directory.CreateDirectory(directoryName);
            }
            catch (Exception)
            {

                throw;
            }
        }   

        public FileUpload SaveToDatabase(string diskBasepath, string appBasepath, string basepath, string filename, int filesize, string mime)
        {
            FileUpload upload = new FileUpload();
            upload.DiskBasepath = diskBasepath;
            upload.AppBasepath = appBasepath.Replace("~/", "").Replace("/", "\\");
            upload.Basepath = basepath + "\\";
            upload.Filename = filename;
            upload.Filesize = filesize;
            upload.Mime = mime;

            return _selfFileUploadRepository.Save(upload);
        }

        public FileUpload Upload(HttpFileCollectionBase files, AuthUser authUser)
        {
            HttpPostedFileBase file = files[0];

            string year;
            string fname;
            string filename;
            string diskBasepath;
            string appBasepath;
            string userPath;
            string directoryPath;
            string userName;

            if (file.FileName.Contains("\\"))
            {
                filename = file.FileName.Split(new char[] { '\\' }).Last();
            }
            else
            {
                filename = file.FileName;
            }

            userName = GetUserName(authUser.CodUsuario).Replace(" ", "_");
            year = "2016"; // Convert.ToString(authUser.ContextoAno);

            var fileUploadBase = ConfigurationManager.AppSettings.Get("fileUploadBase");

            diskBasepath = HttpContext.Current.Server.MapPath("~/");
            appBasepath = HttpContext.Current.Server.MapPath(fileUploadBase);
            userPath = Path.Combine(userName, "SELF_EVALUATION", year);
            directoryPath = Path.Combine(diskBasepath, appBasepath, userPath);
            fname = Path.Combine(directoryPath, filename);

            DirectoryInfo di = CreateDirectory(directoryPath);

            _selfFileSystem.Save(file, fname);

            return SaveToDatabase(diskBasepath, fileUploadBase, userPath, filename, file.ContentLength, file.ContentType);
        }

        public bool Delete(FileUpload obj)
        {
            throw new NotImplementedException();
        }
    }
}
