using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCourrseManagement.Services.Repositorys;
using StudentCourseManagement.Entity.Models.Entity;

namespace StudentCourseManagementSystem.Controllers
{
    [Authorize]
    public class StudentCourseController : Controller
    {
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        //private readonly IInstructorRepository _instructorRepository;

        public StudentCourseController(IStudentCourseRepository studentCourseRepository, 
            ICourseRepository courseRepository, 
            IStudentRepository studentRepository,
            IInstructorRepository instructorRepository)
        {
            _studentCourseRepository = studentCourseRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            //_instructorRepository = instructorRepository;
        }
        //Get Mapping..
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var studentCourse = await _studentCourseRepository.GetAllStudentsCourseAsync();

            return View(studentCourse);
        }

        //post Mapping

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            ViewBag.Students = await _studentRepository.GetAllStudentsAsync();
            ViewBag.Courses = await _courseRepository.GetAllCoursesAsync();
            //ViewBag.Instructors = await _instructorRepository.GetAllInstructorAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(StudentCourses studentCourses)
        {
            if (ModelState.IsValid)
            {
                await _studentCourseRepository.AddStudentCourseAsync(studentCourses);

                return RedirectToAction("Index");

                

            }

            ViewBag.Students = await _studentRepository.GetAllStudentsAsync();
            ViewBag.Courses = await _courseRepository.GetAllCoursesAsync();
            //ViewBag.Instructors = await _instructorRepository.GetAllInstructorAsync();
            return View(studentCourses);


        }
        // Update Mapping..
        [HttpGet]

        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var studentCourses = await _studentCourseRepository.GetStudentsCourseByIdAsync(id);
            if (studentCourses == null)
            {
                return NotFound();
            }
            ViewBag.Students = await _studentRepository.GetAllStudentsAsync();
            ViewBag.Courses = await _courseRepository.GetAllCoursesAsync();
            //ViewBag.Instructors = await _instructorRepository.GetAllInstructorAsync();
            return View(studentCourses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(StudentCourses studentCourses)
        {
            if (ModelState.IsValid)
            {
                await _studentCourseRepository.UpdateStudentCourseAsync(studentCourses);

                return RedirectToAction("Index");

              

            }

            ViewBag.Students = await _studentRepository.GetAllStudentsAsync();
            ViewBag.Courses = await _courseRepository.GetAllCoursesAsync();
            //ViewBag.Instructors = await _instructorRepository.GetAllInstructorAsync();
            return View(studentCourses);
        }

        //Delete Mapping ..

        [HttpGet]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var studentCourses = await _studentCourseRepository.GetStudentsCourseByIdAsync(id);
            if (studentCourses == null)
            {
                return NotFound();
            }
            return View(studentCourses);
        }

        [HttpPost]

        public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
        {

            var studentCourses = await _studentCourseRepository.GetStudentsCourseByIdAsync(id);
            if (studentCourses == null)
            {
                return NotFound();
            }
            //return View(studentCourses);

            await _studentCourseRepository.DeleteStudentCourseAsync(id);
            return RedirectToAction("Index");
        }

        // Get Details ..

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var studentCourses = await _studentCourseRepository.GetStudentsCourseByIdAsync(id);
            if (studentCourses == null)
            {
                return NotFound();
            }
            return View(studentCourses);
        }
    }
}
