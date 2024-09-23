using Microsoft.AspNetCore.Mvc;
using MVCTask1.Data;
using MVCTask1.Models;
using System;

namespace MVCTask1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        } 
        public IActionResult Index()
        {
            var students = dbContext.Students.ToList();  
            return View(nameof(Index),students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student stu)
        {
            dbContext.Students.Add(stu);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));                      
        }
        public IActionResult Update(int id)
        {
            var studentToUpdate = dbContext.Students.Find(id);
            return View(studentToUpdate);
        }
        [HttpPost]
        public IActionResult Update(Student stu)
        {
            var studentToUpdate = dbContext.Students.Find(stu.Id);
            studentToUpdate.Name = stu.Name;
            studentToUpdate.DOB = stu.DOB;
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var studentToRemove=dbContext.Students.Find(id);
            dbContext.Students.Remove(studentToRemove);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
