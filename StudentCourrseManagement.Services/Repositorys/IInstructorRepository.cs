using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourrseManagement.Services.Repositorys
{
    public interface IInstructorRepository
    {
        Task<List<Instructors>> GetAllInstructorAsync();

        Task<Instructors> GetInstructorByIdAsync(int InstructorId);


        Task AddInstructorAsync(Instructors instructors);

        Task UpdateInstructorAsync(Instructors instructors);

        Task DeleteInstructorAsync(int InstructorId);
    }
}
