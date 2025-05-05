using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentCourseManagementSystem.Data;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourrseManagement.Services.Repositorys
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Students>> GetAllStudentsAsync()
        {
            return await _context.students.ToListAsync();
        }

        public async Task<Students> GetStudentsByIdAsync(int StudentId)
        {
            return await _context.students.FindAsync(StudentId);
        }
        public async Task AddStudentAsync(Students students)
        {
             _context.students.Add(students);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Students students)
        {
            _context.students.Update(students);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int StudentId)
        {
            var student = await _context.students.FindAsync(StudentId);
            _context.students.Remove(student);
            await _context.SaveChangesAsync();
        }

       
    }
}
