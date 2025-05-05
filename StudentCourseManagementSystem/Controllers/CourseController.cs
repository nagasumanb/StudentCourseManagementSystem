using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCourrseManagement.Services.Repositorys;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourseManagementSystem.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;   
        }

        //Get Mapping..
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var course = await _courseRepository.GetAllCoursesAsync();

            return View(course);
        }

        //post Mapping

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Courses courses)
        {
            if (ModelState.IsValid)
            {
                await _courseRepository.AddCourseAsync(courses);

                return RedirectToAction("Index");
            }
            return View(courses);
        }
        // Update Mapping..
        [HttpGet]

        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Courses courses)
        {
            if (ModelState.IsValid)
            {
                await _courseRepository.UpdateCourseAsync(courses);

                return RedirectToAction("Index");
            }
            return View(courses);
        }

        //Delete Mapping ..

        [HttpGet]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]

        public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
        {

            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course != null)
            {
                return NotFound();
            }
            return View(course);
        }

        // Get Details ..

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
    }
}
