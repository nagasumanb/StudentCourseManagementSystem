using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourseManagement.Entity.Models.Entity
{
    public class Certificate
    {
        [Key]
        public int CertificateId { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Students Student { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Courses Course { get; set; }

        public int InstructorId { get; set; }
        [ForeignKey("InstructorId")]
        public Instructors Instructor { get; set; }

        public string GradeValue { get; set; }

        public DateTime IssuedOn { get; set; }
    }
}
