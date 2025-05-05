using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentCourseManagement.Entity.Models.Entity;

namespace StudentCourseManagementSystem.Models.Entity
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Description { get; set; }
        //Fk
        [Required]
        public int InstructorId { get; set; }
        //Navigation Property..
        [ForeignKey("InstructorId")]
        [ValidateNever]
        public Instructors instructors { get; set; }
        [ValidateNever]
        public List<Grade> grades { get; set; }

    }
}
