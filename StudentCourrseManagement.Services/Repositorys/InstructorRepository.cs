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
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext _context;

        public InstructorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Instructors>> GetAllInstructorAsync()
        {
            return await _context.instructors.ToListAsync();
        }

        public async Task<Instructors> GetInstructorByIdAsync(int InstructorId)
        {
            return await _context.instructors.FindAsync(InstructorId);
        }

        public async Task AddInstructorAsync(Instructors instructors)
        {
             _context.instructors.Add(instructors);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateInstructorAsync(Instructors instructors)
        {
            _context.instructors.Update(instructors);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInstructorAsync(int InstructorId)
        {
            var instructor = await _context.instructors.FindAsync(InstructorId);
            _context.instructors.Remove(instructor);
            await _context.SaveChangesAsync();
        }

       

       

       
    }
}
