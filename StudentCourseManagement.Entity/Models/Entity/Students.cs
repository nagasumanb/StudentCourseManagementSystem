using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentCourseManagement.Entity.Models.Entity;

namespace StudentCourseManagementSystem.Models.Entity
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Gender { get; set; }

        [ValidateNever]
        public List<Grade> grades { get; set; }




    }
}
