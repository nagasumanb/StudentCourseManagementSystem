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
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Courses>> GetAllCoursesAsync()
        {
            return await _context.courses.ToListAsync();
        }

        public async Task<Courses> GetCourseByIdAsync(int CourseId)
        {
            return await _context.courses.FindAsync(CourseId);
        }

        public async Task AddCourseAsync(Courses courses)
        {
             _context.courses.AddAsync(courses);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Courses courses)
        {
            _context.courses.Update(courses);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteCourseAsync(int CourseId)
        {
            var course = await _context.courses.FindAsync(CourseId);
            _context.courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Courses>> GetCoursesByInstructorIdAsync(int InstructorId)
        {
            return await _context.courses
        .Where(c => c.InstructorId == InstructorId)
        .ToListAsync();
        }
    }
}
