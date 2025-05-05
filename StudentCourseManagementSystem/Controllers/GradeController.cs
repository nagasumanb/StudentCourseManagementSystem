using Microsoft.AspNetCore.Mvc;
using StudentCourrseManagement.Services.Repositorys;
using StudentCourseManagement.Entity.Models.Entity;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourseManagementSystem.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeRepository _gradeRepository;
      

        public GradeController(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
           
        }
        //Get Mapping..
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var grade = await _gradeRepository.GetAllStudentGradeAsync();

            return View(grade);
        }


        //post Mapping

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }




        //[HttpPost]

        //public async Task<IActionResult> Create(Grade grade)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _gradeRepository.AddStudentGradeAsync(grade);

        //        return RedirectToAction("Index");
        //    }
        //    return View(grade);
        //} 

        [HttpPost]
        public async Task<IActionResult> Create(Grade grade, Courses courses)
        {
            var studentCourse = await _gradeRepository.GetStudentCourseAsync(grade.StudentId, grade.CourseId);

            if (studentCourse == null)
            {
                ModelState.AddModelError("", "Invalid student or course.");
                return View(grade);
            }

            if (!studentCourse.HasCompleted)
            {
                ModelState.AddModelError("", "Course is not completed by the student.");
                return View(grade);
            }

            if (ModelState.IsValid)
            {
                await _gradeRepository.AddStudentGradeAsync(grade);

                var certificate = new Certificate
                {
                    StudentId = grade.StudentId,
                    CourseId = grade.CourseId,
                    InstructorId = courses.InstructorId, // Assuming course includes InstructorId
                    GradeValue = grade.GradeValue,
                    IssuedOn = DateTime.Now
                };

                await _gradeRepository.AddCertificateAsync(certificate);

                return RedirectToAction("Index");
            }

            return View(grade);
        }



        // Update Mapping..
        [HttpGet]

        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var grade = await _gradeRepository.GetStudentGradeByIdAsync(id);
            if (grade == null)
            {
                return NotFound();
            }
            return View(grade);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Grade grade)
        {
            if (ModelState.IsValid)
            {
                await _gradeRepository.UpdateStudentGradeAsync(grade);

                return RedirectToAction("Index");
            }
            return View(grade);
        }

        //Delete Mapping ..

        [HttpGet]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var grade = await _gradeRepository.GetStudentGradeByIdAsync(id);
            if (grade == null)
            {
                return NotFound();
            }
            return View(grade);
        }

        [HttpPost]

        public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
        {

            var grade = await _gradeRepository.GetStudentGradeByIdAsync(id);
            if (grade != null)
            {
                return NotFound();
            }
            return View(grade);
        }

        // Get Details ..

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var grade = await _gradeRepository.GetStudentGradeByIdAsync(id);
            if (grade == null)
            {
                return NotFound();
            }
            return View(grade);
        }
    }
}
