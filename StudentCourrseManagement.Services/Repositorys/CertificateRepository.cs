using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentCourseManagement.Entity.Models.Entity;
using StudentCourseManagementSystem.Data;

namespace StudentCourrseManagement.Services.Repositorys
{
    public class CertificateRepository: ICertificateRepository
    {
        private readonly AppDbContext _context;

        public CertificateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCertificateAsync(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Certificate>> GetAllCertificatesAsync()
        {
            return await _context.Certificates
           .Include(c => c.Student)
           .Include(c => c.Course)
           .Include(c => c.Instructor)
           .ToListAsync();
        }

        public async Task<Certificate> GetCertificateByIdAsync(int id)
        {
            return await _context.Certificates
           .Include(c => c.Student)
           .Include(c => c.Course)
           .Include(c => c.Instructor)
           .FirstOrDefaultAsync(c => c.CertificateId == id);
        }
    }
}
