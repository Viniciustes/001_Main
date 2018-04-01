namespace CTJEvaluation001.Domain.Entities
{
    public class Employee
    {
        public string Chapa { get; set; }
        public string Name { get; set; }
        public Person Person { get; set; }
        public string Role { get; set; }
        public string RoleId { get; set; }
    }
}