namespace EmployeeM.Models
{
    public class ThemeEntity
    {
        public int Id { get; set; }
        public string? BodyBGColor { get; set; }
        public string? BodyColor { get; set; }
        public string? HeaderFooterBGColor { get; set; }
        public string? HeaderFooterColor { get; set; }


        // Foreign Key reference to Department
        public int DepartmentId { get; set; }

        public DepartmentEntity? Department { get; set; }
    }
}
