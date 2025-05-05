using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentCourseManagementSystem.Models.Entity
{
    public class Instructors
    {
        [Key]
        public int InstructorId { get; set; }
        [Required]
        public string InstructorName { get; set; }
        [Required]
        public string InstructorEmail { get; set; }

        [ValidateNever]
        public List<Courses> courses { get; set; }

    }
}
