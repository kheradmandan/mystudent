using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Students.Domain.Entities;
using Students.Persistence.DbContexts;
using Students.Services.Repositories;
using Students.Services.Service;

namespace Students.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesController : Controller
    {
        private readonly StudentDbContext _context;
        private ICourse courseRepository;
        private ICI_FieldCourse cI_FieldCourseRepository;
        private ITeacher teacherRepository;
        public CoursesController( ICourse course, ICI_FieldCourse cI_FieldCourse , ITeacher teacher )
        {
      
            courseRepository = course;
            cI_FieldCourseRepository = cI_FieldCourse;
            teacherRepository =  teacher;
        }
    

        // GET: Admin/Courses
        public async Task<IActionResult> Index()
        {

            return View(courseRepository.GetAllCourses());
        }

        // GET: Admin/Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {


            var course = courseRepository.GetCourseById(id.Value);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Admin/Courses/Create
        public IActionResult Create()
        {
            ViewData["CI_FieldCourseId"] = new SelectList(cI_FieldCourseRepository.GetAllCI_FieldCourses(), "Id", "Title");
            ViewData["TeacherId"] = new SelectList(teacherRepository.GetAllTeachers(), "Id", "Name");
            return View();
        }

        // POST: Admin/Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Classtime,TimeOfSession,TeacherId,CI_FieldCourseId")] Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepository.InsertCourse(course);
                courseRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CI_FieldCourseId"] = new SelectList(cI_FieldCourseRepository.GetAllCI_FieldCourses(), "Id", "Title", course.CI_FieldCourseId);
            ViewData["TeacherId"] = new SelectList(teacherRepository.GetAllTeachers(), "Id", "Name", course.TeacherId);
            return View(course);
        }

        // GET: Admin/Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            var course = courseRepository.GetCourseById(id.Value);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["CI_FieldCourseId"] = new SelectList(cI_FieldCourseRepository.GetAllCI_FieldCourses(), "Id", "Title", course.CI_FieldCourseId);
            ViewData["TeacherId"] = new SelectList(teacherRepository.GetAllTeachers(), "Id", "Name", course.TeacherId);
            return View(course);
        }

        // POST: Admin/Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Classtime,TimeOfSession,TeacherId,CI_FieldCourseId")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    courseRepository.UpdateCourse(course);
                    courseRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {


                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CI_FieldCourseId"] = new SelectList(cI_FieldCourseRepository.GetAllCI_FieldCourses(), "Id", "Title", course.CI_FieldCourseId);
            ViewData["TeacherId"] = new SelectList(teacherRepository.GetAllTeachers(), "Id", "Name", course.TeacherId);
            return View(course);
        }

        // GET: Admin/Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {


            var course = courseRepository.GetCourseById(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Admin/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var course = courseRepository.GetCourseById(id);
            if (course != null)
            {
                courseRepository.DeleteCourse(course);
            }

            courseRepository.Save();
            return RedirectToAction(nameof(Index));
        }

     
    }
}
