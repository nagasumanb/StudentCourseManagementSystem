using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourseManagement.Entity.Models.Entity
{
    public class Grade
    {
        public int GradeId { get; set; }

        public string GradeValue { get; set; }
        //Fk
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Students? students { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Courses? courses { get; set; }


    }
}
