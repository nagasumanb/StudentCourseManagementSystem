using Microsoft.EntityFrameworkCore;
using StudentCourseManagement.Entity.Models.Entity;
using StudentCourseManagementSystem.Data;

namespace StudentCourrseManagement.Services.Repositorys
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly AppDbContext _context;

        public StudentCourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentCourses>> GetAllStudentsCourseAsync()
        {
            //return await _context.studentCourses.ToListAsync();

            return await _context.studentCourses
                        .Include(sc => sc.Student)
                        .Include(sc => sc.Course)
                        //.Include(sc => sc.instructors)
                        .ToListAsync();
        }

        public async Task<StudentCourses> GetStudentsCourseByIdAsync(int Id)
        {
            //return await _context.studentCourses.FindAsync(Id);

            return await _context.studentCourses
        .Include(sc => sc.Student)
        .Include(sc => sc.Course)
        //.Include(sc => sc.instructors)
        .FirstOrDefaultAsync(sc => sc.Id == Id);
        }
        public async Task AddStudentCourseAsync(StudentCourses studentCourses)
        {
            _context.studentCourses.AddAsync(studentCourses);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentCourseAsync(StudentCourses studentCourses)
        {
            _context.studentCourses.Update(studentCourses);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentCourseAsync(int Id)
        {
            var studentCourse = await _context.studentCourses.FindAsync(Id);

            _context.studentCourses.Remove(studentCourse);
            await _context.SaveChangesAsync();
        }
        
    }
}
