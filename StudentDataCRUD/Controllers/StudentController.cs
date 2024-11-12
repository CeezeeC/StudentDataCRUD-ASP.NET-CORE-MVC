using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDataCRUD.AppDbContext;
using StudentDataCRUD.Models;
namespace StudentDataCRUD.Controllers
{
    public class StudentController : Controller
    {
        public readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext dbContext)
        {
          _studentDbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel viewModel)
        {
            var student = new Student
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Course = viewModel.Course,
                Subscribed = viewModel.Subscribed,
            };
            await _studentDbContext.students.AddAsync(student);

            await _studentDbContext.SaveChangesAsync();
            return RedirectToAction("Create","Student");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await _studentDbContext.students.ToListAsync();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _studentDbContext.students.FindAsync(id);

            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewStudent)
        {
            var student = await _studentDbContext.students.FindAsync(viewStudent.Id);

            if (student is not null)
            {
                student.FirstName = viewStudent.FirstName;
                student.LastName = viewStudent.LastName;
                student.Course = viewStudent.Course;
                student.Subscribed = viewStudent.Subscribed;

                await _studentDbContext.SaveChangesAsync();
            }
            
            return RedirectToAction("List", "Student");
        }
       
        [HttpPost]
        public async Task<IActionResult> Delete(Student viewStudent)
        {
            var student = await _studentDbContext.students.AsNoTracking().
                FirstOrDefaultAsync( x => x.Id == viewStudent.Id);

            if (student is not null)
            {
                _studentDbContext.students.Remove(viewStudent);
               await _studentDbContext.SaveChangesAsync();

                
            }

            return RedirectToAction("List", "Student");
        }
    }
}
