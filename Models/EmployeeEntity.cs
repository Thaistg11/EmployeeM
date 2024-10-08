using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeM.Models
{
    public class EmployeeEntity
    {
        [Key]
       
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        [DisplayName("Date of birth")]
        public string DOB { get; set; }


        // Foreign Key reference to Department
        public int DepartmentId { get; set; }  
        public DepartmentEntity? Department { get; set; } 
    }

}