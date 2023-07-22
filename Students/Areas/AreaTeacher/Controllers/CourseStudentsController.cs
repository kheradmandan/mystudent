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
    [Area("AreaTeacher")]
    public class CourseStudentsController : Controller
    {
        private readonly StudentDbContext _context;
        private ICourseStudent courseStudentRepository;
        private ITeacher teacherRepository;
        private ICourse courseRepository;
        private IStudent studentRepository;
        public CourseStudentsController(ICourseStudent courseStudent, ITeacher teacher)
        {
       
            courseStudentRepository = courseStudent;
            teacherRepository = teacher;
    
        }

  


        // GET: AreaStudent/CourseStudents
        public async Task<IActionResult> Index()
        {
           
    
            if (teacherRepository.GetIdByUserName(GlobalVariable.UserName) == 0)
            {
                TempData["notExistProfileIndex"] = " ابتدا پروفایل را تکمیل بفرمایید ";
                return RedirectToAction("Index", "Home", new { area = "AreaTeacher" });

            }

            var SelectedTeacheId= teacherRepository.GetIdByUserName(GlobalVariable.UserName);

            if (courseStudentRepository.GetCourseStudentByTeacheId(SelectedTeacheId) ==null)
            {
                TempData["CourseStudentNull"] = " هیچ کلاسی به شما اختصاص داده نشده است  ";
                return RedirectToAction("Index", "Home", new { area = "AreaTeacher" });
              //  return RedirectToAction("Create");
            }
            return View(courseStudentRepository.GetCourseStudentByTeacheId(SelectedTeacheId));
        }


    }
}
