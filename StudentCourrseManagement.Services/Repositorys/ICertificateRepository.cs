using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseManagement.Entity.Models.Entity;

namespace StudentCourrseManagement.Services.Repositorys
{
    public interface ICertificateRepository
    {
        Task<List<Certificate>> GetAllCertificatesAsync();
        Task<Certificate> GetCertificateByIdAsync(int id);
        Task AddCertificateAsync(Certificate certificate);
    }
}
