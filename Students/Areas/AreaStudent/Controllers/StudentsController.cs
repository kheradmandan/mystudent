using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students.Domain.Entities;
using Students.Persistence.DbContexts;
using Students.Services.Repositories;
using Students.Services.Service;

namespace Students.Areas.AreaStudent.Controllers
{
    [Area("AreaStudent")]
    public class StudentsController : Controller
    {
        private readonly StudentDbContext _context;
        private IStudent studentRepository;
        private ICI_FieldStudent cI_FieldStudentRepository;
        public StudentsController(IStudent student , ICI_FieldStudent cI_FieldStudent )
        {
         
            studentRepository = student;
            cI_FieldStudentRepository = cI_FieldStudent;
        }

    
        // GET: AreaStudent/Students/Create
        public IActionResult Create()
        {
            ViewData["CI_FieldStudentId"] = new SelectList(cI_FieldStudentRepository.GetAllCI_FieldStudents(), "Id", "Title");
            return View();
        }

        // POST: AreaStudent/Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Name,Age,NationalCode,CI_FieldStudentId")] Student student)
        {
            


           student.UserName = GlobalVariable.UserName;
            if (ModelState.IsValid)
            {
                if (studentRepository.IExisitUserName(GlobalVariable.UserName))
                {
                    TempData["MessageStudent"] = "نام کاربری قبلا ثبت شده است و فقط با یوزر admin  قابل ویرایش است ";
                    ViewData["CI_FieldStudentId"] = new SelectList(cI_FieldStudentRepository.GetAllCI_FieldStudents(), "Id", "Title", student.CI_FieldStudentId);
                    return RedirectToAction("Create", "Students", new { area = "AreaStudent" });
                }
               
                studentRepository.InsertStudent(student);
                studentRepository.Save();
                // return RedirectToAction(nameof(Index));
                // return View("~/Views/Home/index.cshtml");
                return RedirectToAction("Index", "Home", new { area = "AreaStudent" });
            }
            ViewData["CI_FieldStudentId"] = new SelectList(cI_FieldStudentRepository.GetAllCI_FieldStudents(), "Id", "Title", student.CI_FieldStudentId);
            return View(student);
        }

     
    }
}
