using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCourrseManagement.Services.Repositorys;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourseManagementSystem.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //Get Mapping..
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var student = await _studentRepository.GetAllStudentsAsync();

            return View(student);
        }

        //post Mapping

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]

        //public async Task<IActionResult> Create(Students students)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        await _studentRepository.AddStudentAsync(students);

        //        return RedirectToAction("Index");
        //    }
        //    return View(students);
        //}

        [HttpPost]
        public async Task<IActionResult> Create(Students students)
        {
            if (!ModelState.IsValid)
            {
                // Log all validation errors
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"ModelState Error for '{key}': {error.ErrorMessage}");
                    }
                }
                return View(students);
            }

            await _studentRepository.AddStudentAsync(students);
            return RedirectToAction("Index");
        }

        // Update Mapping..
        [HttpGet]

        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var student = await _studentRepository.GetStudentsByIdAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Students students)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.UpdateStudentAsync(students);

                return RedirectToAction("Index");
            }
            return View(students);
        }

        //Delete Mapping ..

        [HttpGet]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var student = await _studentRepository.GetStudentsByIdAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]

        public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
        {

            var existingCustomer = await _studentRepository.GetStudentsByIdAsync(id);
            if (existingCustomer != null)
            {
                return NotFound();
            }
            return View(existingCustomer);
        }

        // Get Details ..

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute]int id)
        {
            var customer = await _studentRepository.GetStudentsByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

    }
}
