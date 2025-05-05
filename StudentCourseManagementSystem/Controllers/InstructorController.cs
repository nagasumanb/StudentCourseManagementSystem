using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCourrseManagement.Services.Repositorys;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourseManagementSystem.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        //Get Mapping..
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var instructor = await _instructorRepository.GetAllInstructorAsync();

            return View(instructor);
        }

        //post Mapping

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Instructors instructors)
        {
            if (ModelState.IsValid)
            {
                await _instructorRepository.AddInstructorAsync(instructors);

                return RedirectToAction("Index");
            }
            return View(instructors);
        }
        // Update Mapping..
        [HttpGet]

        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var instructor = await _instructorRepository.GetInstructorByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Instructors instructors)
        {
            if (ModelState.IsValid)
            {
                await _instructorRepository.UpdateInstructorAsync(instructors);

                return RedirectToAction("Index");
            }
            return View(instructors);
        }

        //Delete Mapping ..

        [HttpGet]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var instructor = await _instructorRepository.GetInstructorByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        [HttpPost]

        public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
        {

            var instructor = await _instructorRepository.GetInstructorByIdAsync(id);
            if (instructor != null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        // Get Details ..

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var instructor = await _instructorRepository.GetInstructorByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }
    }
}
