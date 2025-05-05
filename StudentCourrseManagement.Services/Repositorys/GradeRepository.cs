using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentCourseManagement.Entity.Models.Entity;
using StudentCourseManagementSystem.Data;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourrseManagement.Services.Repositorys
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AppDbContext _context;

        public GradeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Grade>> GetAllStudentGradeAsync()
        {
            return await _context.grades.ToListAsync();
        }

        public async Task<Grade> GetStudentGradeByIdAsync(int GradeId)
        {
            return await _context.grades.FindAsync(GradeId);
        }
        public async Task AddStudentGradeAsync(Grade grade)
        {
            _context.grades.AddAsync(grade);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentGradeAsync(Grade grade)
        {
            _context.grades.Update(grade);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteStudentGradeAsync(int GradeId)
        {
            var grade = await _context.grades.FindAsync(GradeId);
            _context.grades.Remove(grade);
            await _context.SaveChangesAsync();
        }

        public async Task<StudentCourses?> GetStudentCourseAsync(int studentId, int courseId)
        {
            return await _context.studentCourses
       .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
        }

        public async Task AddCertificateAsync(Certificate certificate)
        {
            await _context.Certificates.AddAsync(certificate);
            await _context.SaveChangesAsync();
        }

        public async Task<Courses> GetCourseByIdAsync(int courseId)
        {
            
            var course = await _context.courses
                                       .FirstOrDefaultAsync(c => c.CourseId == courseId);

            return course;
        }
    }
}
