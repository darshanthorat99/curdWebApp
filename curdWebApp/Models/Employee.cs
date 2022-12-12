using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace curdWebApp.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage ="NAME IS REQUIRED")]
        [MaxLength(20)]

        public string? Name { get; set; }


        [Required(ErrorMessage = "Conact number IS REQUIRED")]
        public string? Contact { get; set; }

        [Required(ErrorMessage = "Department IS REQUIRED")]
       
        public string? Department { get; set; }


        [Required(ErrorMessage = "Salary NOT FOUND")]

        public  double? Salary { get; set; }

    }
}
