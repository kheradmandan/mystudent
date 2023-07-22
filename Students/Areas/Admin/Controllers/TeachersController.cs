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

namespace Students.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeachersController : Controller
    {
        private readonly StudentDbContext _context;

        private ITeacher teacherRepository;
        private IUser userRepository;
        public TeachersController( ITeacher teacher , IUser user )
        {
          
            teacherRepository = teacher;
            userRepository = user;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.teacherRepository != null)
                {
                    this.teacherRepository.Dispose();
                    this.teacherRepository = null;
                }
          

            }

            base.Dispose(disposing);
        }


        // GET: Admin/Teachers
        public async Task<IActionResult> Index()
        {
              return View(teacherRepository.GetAllTeachers());
        }

        // GET: Admin/Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {


            var teacher = teacherRepository.GetTeacherById(id.Value);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Admin/Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Name,Mob")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var Selectuser = userRepository.GetUserForLogin(teacher.UserName);
                if (Selectuser == null)
                {
                    TempData["MessageSabteUserT"] = "لطفا ابتدا نام کاربر را در لیست کاربران ثبت بفرمایید ";
                    return View(teacher);
                }
                if (Selectuser.CI_RoleId != 2)
                {
                    TempData["MessageErorrRolTeacher"] = "نام کاربری متعلق به معلم نیست ";
                    return View(teacher);
                }

                teacherRepository.InsertTeacher(teacher);
                teacherRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Admin/Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            var teacher = teacherRepository.GetTeacherById(id.Value);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Admin/Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Name,Mob")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    teacherRepository.UpdateTeacher(teacher);
                    teacherRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                  
                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Admin/Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {


            var teacher = teacherRepository.GetTeacherById(id.Value);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Admin/Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var teacher = teacherRepository.GetTeacherById(id);
            if (teacher != null)
            {
                teacherRepository.DeleteTeacher(id);
            }

            teacherRepository.Save();
            return RedirectToAction(nameof(Index));
        }

    
     
    }
}
