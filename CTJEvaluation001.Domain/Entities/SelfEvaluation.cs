using System.Collections.Generic;

namespace CTJEvaluation001.Domain.Entities
{
    public class SelfEvaluation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CTJEvents Question1 { get; set; }
        public CTJEvents Question2 { get; set; }
        public CTJEvents Question2A { get; set; }
        public int? CtjEvents01Confirm { get; set; }
        public int? CtjEvents02Confirm { get; set; }
        public int? CtjEvents02AConfirm { get; set; }
        public string Chapa { get; set; }
        public int? Ano { get; set; }
        public int? Degree { get; set; }
        public int? DegreeImageId { get; set; }
        public FileUpload DegreeImage { get; set; }
        public int? DegreeComplete { get; set; }
        public int? CertificateOfProficiency { get; set; }

        public IEnumerable<ProfessionalDevelopment> ProfessionalDevelopments { get; set; }
        public IEnumerable<DigitalLiteracy> DigitalLiteracies { get; set; }
        public string DigitalProject { get; set; }
        public IEnumerable<ProjectActivity> ProjectActivities { get; set; }
        
        public string FinalReflectionA { get; set; }
        public string FinalReflectionB { get; set; }
        public string FinalReflectionC { get; set; }
        public string FinalReflectionD { get; set; }
        public string FinalReflectionE { get; set; }
        public string FinalReflectionF { get; set; }
        public string FinalReflectionG { get; set; }
    }
}