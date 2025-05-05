using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseManagement.Entity.Models.Entity;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourrseManagement.Services.Repositorys
{
    public interface IGradeRepository
    {
        Task<List<Grade>> GetAllStudentGradeAsync();

        Task<Grade> GetStudentGradeByIdAsync(int GradeId);


        Task AddStudentGradeAsync(Grade grade);

        Task UpdateStudentGradeAsync(Grade grade);

        Task DeleteStudentGradeAsync(int GradeId);

        Task<StudentCourses?> GetStudentCourseAsync(int studentId, int courseId);


        Task AddCertificateAsync(Certificate certificate);
        Task<Courses> GetCourseByIdAsync(int courseId);


    }
}
