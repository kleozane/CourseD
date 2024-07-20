using Course.Data;
using Microsoft.AspNetCore.Mvc;
using Course.Models;

namespace Course.Controllers
{
    public class StudentController : Controller
    {
        private readonly CourseContext _context;

        public StudentController(CourseContext courseContext) 
        {
            _context = courseContext;
        }

        public IActionResult Index()
        {
            var studentet = _context.Students.ToList();
            return View(studentet);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new StudentForCreation();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(StudentForCreation model)
        {
            var student = new Student
            {
                Name = model.Name
            };

            _context.Add(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            var model = new StudentForMod
            {
                Id = student.Id,
                Name = student.Name
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StudentForMod model)
        {
            var student = new Student
            {
                Id = model.Id,
                Name = model.Name
            };

            _context.Update(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            _context.Remove(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
