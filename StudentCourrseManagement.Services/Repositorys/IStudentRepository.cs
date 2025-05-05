using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourrseManagement.Services.Repositorys
{
    public interface IStudentRepository
    {
        Task <List<Students>> GetAllStudentsAsync();

        Task<Students> GetStudentsByIdAsync(int StudentId);


        Task AddStudentAsync(Students students);

        Task UpdateStudentAsync(Students students);

        Task DeleteStudentAsync(int StudentId);




    }
}
