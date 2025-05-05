using Microsoft.AspNetCore.Mvc;
using StudentCourrseManagement.Services.Repositorys;
using StudentCourseManagement.Entity.Models.Entity;

namespace StudentCourseManagementSystem.Controllers
{
    public class CertificateController : Controller
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IGradeRepository _gradeRepository;

        public CertificateController(IGradeRepository gradeRepository, ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
            _gradeRepository = gradeRepository; 
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var certificates = await _certificateRepository.GetAllCertificatesAsync();
            return View(certificates);
        }

        [HttpGet]
        public async Task<IActionResult> Generate(int gradeId)
        {
            var grade = await _gradeRepository.GetStudentGradeByIdAsync(gradeId);
            if (grade == null)
                return NotFound();

            var certificate = new Certificate
            {
                StudentId = grade.StudentId,
                CourseId = grade.CourseId,
                GradeValue = grade.GradeValue,
                InstructorId = grade.courses.InstructorId, // Assuming Courses has InstructorId
                IssuedOn = DateTime.Now
            };

            await _certificateRepository.AddCertificateAsync(certificate);

            return RedirectToAction("Index");
        }
    }
}
