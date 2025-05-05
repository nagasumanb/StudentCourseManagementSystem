using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseManagement.Entity.Models.Entity;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourrseManagement.Services.Repositorys
{
    public interface IStudentCourseRepository
    {
        Task<List<StudentCourses>> GetAllStudentsCourseAsync();

        Task<StudentCourses> GetStudentsCourseByIdAsync(int Id);


        Task AddStudentCourseAsync(StudentCourses studentCourses);

        Task UpdateStudentCourseAsync(StudentCourses studentCourses);

        Task DeleteStudentCourseAsync(int Id);
    }
}
