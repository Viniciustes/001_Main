namespace CTJEvaluation001.Domain.Entities
{
    public class FileUpload
    {
        public int Id { get; set; }
        public string DiskBasepath { get; set; }
        public string AppBasepath { get; set; }
        public string Basepath { get; set; }
        public string Filename { get; set; }
        public int Filesize { get; set; }
        public string Mime { get; set; }
    }
}
