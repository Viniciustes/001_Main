namespace CTJEvaluation001.Domain.Entities.System
{
    public class MenuAction
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Title { get; set; }
        public string CodPerfil { get; set; }
        public string HtmlClass { get; set; }
        public string HtmlId { get; set; }
        public string HtmlIcon { get; set; }
    }
}