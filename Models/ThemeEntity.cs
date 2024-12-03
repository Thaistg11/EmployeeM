using System.ComponentModel;

namespace EmployeeM.Models
{
    public class ThemeEntity
    {
        public int? Id { get; set; }

        [DisplayName("Home Page Background Color")]
        public string? BodyBGColor { get; set; }

        [DisplayName("Home Page Font Color")]
        public string? BodyColor { get; set; }

        [DisplayName("Header and Footer Background Color")]
        public string? HeaderFooterBGColor { get; set; }

        [DisplayName("Header and Footer Font Color")]
        public string? HeaderFooterColor { get; set; }


        // Foreign Key reference to Department
        public int DepartmentId { get; set; }

        public DepartmentEntity? Department { get; set; }
    }
}
