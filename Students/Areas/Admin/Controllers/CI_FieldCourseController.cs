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
    public class CI_FieldCourseController : Controller
    {
        private readonly StudentDbContext _context;
        private ICI_FieldCourse cI_FieldCourseRepository;
        public CI_FieldCourseController(ICI_FieldCourse cI_FieldCourse)
        {
      
            cI_FieldCourseRepository = cI_FieldCourse;
        }
        public async Task<IActionResult> Index()
        {
            return View(cI_FieldCourseRepository.GetAllCI_FieldCourses());
        }
        public async Task<IActionResult> Details(int? id)
        {
            var cI_FieldCourse = cI_FieldCourseRepository.GetCI_FieldCourseById(id.Value);
            if (cI_FieldCourse == null)
            {
                return NotFound();
            }
            return View(cI_FieldCourse);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] CI_FieldCourse cI_FieldCourse)
        {
            if (ModelState.IsValid)
            {
                cI_FieldCourseRepository.InsertCI_FieldCourse(cI_FieldCourse);
                cI_FieldCourseRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cI_FieldCourse);
        }

        // GET: Admin/CI_FieldCourse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var cI_FieldCourse = cI_FieldCourseRepository.GetCI_FieldCourseById(id.Value);
            if (cI_FieldCourse == null)
            {
                return NotFound();
            }
            return View(cI_FieldCourse);
        }

        // POST: Admin/CI_FieldCourse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] CI_FieldCourse cI_FieldCourse)
        {
            if (id != cI_FieldCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cI_FieldCourseRepository.UpdateCI_FieldCourse(cI_FieldCourse);
                    cI_FieldCourseRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cI_FieldCourse);
        }

        // GET: Admin/CI_FieldCourse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {


            var cI_FieldCourse = cI_FieldCourseRepository.GetCI_FieldCourseById(id.Value);
            if (cI_FieldCourse == null)
            {
                return NotFound();
            }

            return View(cI_FieldCourse);
        }

        // POST: Admin/CI_FieldCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var cI_FieldCourse = cI_FieldCourseRepository.GetCI_FieldCourseById(id);
            if (cI_FieldCourse != null)
            {
                cI_FieldCourseRepository.DeleteCI_FieldCourse(cI_FieldCourse);
            }

            cI_FieldCourseRepository.Save();
            return RedirectToAction(nameof(Index));
        }


    }
}
