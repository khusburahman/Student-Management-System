using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.DatabaseContext;
using SMS.Models;

namespace SMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public StudentController(ApplicationDBContext context)
        {
            _dbContext = context;
        }
        
        public async Task <IActionResult> Index()
        {
            var data=await _dbContext.Set<Student>().AsNoTracking().ToListAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult>CreateOrEdit(int Id)
        {
            if (Id == 0)
            {
                return View(new Student());
            }
            else
            {
                var data = await _dbContext.Set<Student>().FindAsync(Id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(int Id,Student student)
        {
            if (Id == 0)
            {
                if (ModelState.IsValid)
                {
                    await _dbContext.Set<Student>().AddAsync(student);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            //edit
            else
            {
                _dbContext.Set<Student>().Update(student);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        //delete
        public async Task<IActionResult>Delete(int Id)
        {
            if(Id != 0)
            {
                var data = await _dbContext.Set<Student>().FindAsync(Id);
                if(data is not null)
                {
                    _dbContext.Set<Student>().Remove(data);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>Details(int Id)
        {
            var data = await _dbContext.Set<Student>().FindAsync(Id);
            return View(data);
        }

    }
}
