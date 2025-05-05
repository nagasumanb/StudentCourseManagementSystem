using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourrseManagement.Services.Repositorys
{
    public interface ICourseRepository
    {
        Task<List<Courses>> GetAllCoursesAsync();

        Task<Courses> GetCourseByIdAsync(int CourseId);


        Task AddCourseAsync(Courses courses);

        Task UpdateCourseAsync(Courses courses);

        Task DeleteCourseAsync(int CourseId);

        Task<IEnumerable<Courses>> GetCoursesByInstructorIdAsync(int InstructorId);

    }
}
