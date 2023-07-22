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
    public class CoursesController : Controller
    {
        private readonly StudentDbContext _context;
        private ICourse courseRepository;
        private ICI_FieldCourse cI_FieldCourseRepository;
        private ITeacher teacherRepository;
        public CoursesController(ICourse course,ICI_FieldCourse cI_FieldCourse, ITeacher teacher )
        {
        
            courseRepository = course;
            cI_FieldCourseRepository = cI_FieldCourse;
            teacherRepository = teacher;
        }

        // GET: AreaStudent/Courses
        public async Task<IActionResult> Index()
        {
            
            return View(courseRepository.GetAllCourses());
        }

      
    }
}
