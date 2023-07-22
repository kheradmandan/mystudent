using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using Students.Domain.Entities;
using Students.Persistence.DbContexts;
using Students.Services.Repositories;
using Students.Services.Service;

namespace Students.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentsController : Controller
    {
        private readonly StudentDbContext _context;
        private IStudent studentRepository;
        private ICI_FieldStudent cI_FieldStudentRepository;
        private IUser userRepository;
        public StudentsController(IStudent student,ICI_FieldStudent cI_FieldStudent,IUser user )
        {
        
            studentRepository = student;
            cI_FieldStudentRepository = cI_FieldStudent;
            userRepository = user;
        }
  
        // GET: Admin/Students
        public async Task<IActionResult> Index()
        {
          return View(studentRepository.GetAllStudents());
        }

        // GET: Admin/Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {


            var student = studentRepository.GetStudentById(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Admin/Students/Create
        public IActionResult Create()
        {
            ViewData["CI_FieldStudentId"] = new SelectList(cI_FieldStudentRepository.GetAllCI_FieldStudents(), "Id", "Title");
            return View();
        }

        // POST: Admin/Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Name,Age,NationalCode,CI_FieldStudentId")] Student student)
        {
            if (ModelState.IsValid)
            {
                var Selectuser = userRepository.GetUserForLogin(student.UserName);
                if (Selectuser == null)
                {
                    TempData["MessageSabtUserS"] = "لطفا ابتدا نام کاربر را در لیست کاربران ثبت بفرمایید ";
                    return View(student);
                }
                if (Selectuser.CI_RoleId!=3)
                {
                    TempData["MessageErorrRol"] = "نام کاربری متعلق به دانش آموز نیست ";
                    return View(student);
                }
                studentRepository.InsertStudent(student);
                studentRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CI_FieldStudentId"] = new SelectList(cI_FieldStudentRepository.GetAllCI_FieldStudents(), "Id", "Title", student.CI_FieldStudentId);
            return View(student);
        }

        // GET: Admin/Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            var student = studentRepository.GetStudentById(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CI_FieldStudentId"] = new SelectList(cI_FieldStudentRepository.GetAllCI_FieldStudents(), "Id", "Title", student.CI_FieldStudentId);
            return View(student);
        }

        // POST: Admin/Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Name,Age,NationalCode,CI_FieldStudentId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    studentRepository.UpdateStudent(student);
                    studentRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                 
                    
                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CI_FieldStudentId"] = new SelectList( cI_FieldStudentRepository.GetAllCI_FieldStudents(), "Id", "Title", student.CI_FieldStudentId);
            return View(student);
        }

        // GET: Admin/Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {


            var student = studentRepository.GetStudentById(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Admin/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var student = studentRepository.GetStudentById(id);
            if (student != null)
            {
                studentRepository.DeleteStudent(student);
            }

            studentRepository.Save();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
