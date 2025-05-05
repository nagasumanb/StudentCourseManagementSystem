using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourseManagement.Entity.Models.Entity
{
    [Table("StudentCourses")]
    public class StudentCourses
    {
        public int Id { get; set; }
       
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Students? Student { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Courses? Course { get; set; }

        //public int InstructorId { get; set; }

        //[ForeignKey("InstructorId")]

        //public Instructors? instructors { get; set; }


        public bool HasCompleted { get; set; }
    }
}
