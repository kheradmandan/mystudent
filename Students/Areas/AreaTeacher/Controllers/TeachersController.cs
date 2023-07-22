using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students.Domain.Entities;
using Students.Models;
using Students.Persistence.DbContexts;
using Students.Services.Repositories;
using Students.Services.Service;

namespace Students.Areas.AreaTeacher.Controllers
{
    [Area("AreaTeacher")]
    public class TeachersController : Controller
    {
        private readonly StudentDbContext _context;
        private ITeacher teacherRepository;
        private ICourseStudent courseStudentRepository;
        private IStudent studentRepository;
        private int GlobalCoursId  ;
        public TeachersController(ITeacher teacher,ICourseStudent courseStudent,IStudent student)
        {
            teacherRepository = teacher;
            courseStudentRepository= courseStudent;
            studentRepository= student;
       
        }

        public async Task<IActionResult> Index()
        {
        

            if (teacherRepository.GetIdByUserName(GlobalVariable.UserName) == 0)
            {
                TempData["notExistProfileIndex"] = " ابتدا پروفایل را تکمیل بفرمایید ";
                return RedirectToAction("Index", "Home", new { area = "AreaTeacher" });

            }

            var SelectedTeacheId = teacherRepository.GetIdByUserName(GlobalVariable.UserName);
      
            if (teacherRepository.GetTeacherById(SelectedTeacheId).Courses == null)
            {
                TempData["CourseStudentNull"] = " هیچ کلاسی به شما اختصاص داده نشده است  ";
                return RedirectToAction("Index", "Home", new { area = "AreaTeacher" });
                //  return RedirectToAction("Create");
            }
            return View(teacherRepository.GetTeacherById(SelectedTeacheId).Courses);
        }


        // GET: AreaTeacher/Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AreaTeacher/Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Name,Mob")] Teacher teacher)
        {
            teacher.UserName = GlobalVariable.UserName;
            if (teacherRepository.IExisitUserName(GlobalVariable.UserName))
            {
                TempData["MessageStudentTeacher"] = "نام کاربری قبلا ثبت شده است و فقط با یوزر admin  قابل ویرایش است ";

                return RedirectToAction("Create", "Teachers", new { area = "AreaTeacher" });
            }

            if (ModelState.IsValid)
            {
                teacherRepository.InsertTeacher(teacher);
                teacherRepository.Save();
                return RedirectToAction("Index", "Home", new { area = "AreaTeacher" });
                // return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }


        public async Task<IActionResult> Edit(int? id)
        {

         
            var Students = courseStudentRepository.GetStudentsByCoursId(id.Value);
            if (Students == null)
            {
                return NotFound();
            }
            var MyStudentNomre = Students.Select(p => new StudentNomreViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age,
                NationalCode = p.NationalCode,
                UserName = p.UserName,
                Nomre = "0",
                CourseId=id.Value,
                
            });

             var newList = new List<StudentNomreViewModel>();
            foreach (var item in MyStudentNomre)
            {
                var MCoursStudent = courseStudentRepository.GetCourseStudentIdByStudentIdAndCoursId(item.Id,id.Value);
                  item.Nomre = courseStudentRepository.GetCourseStudentById(MCoursStudent).Nomre;
                newList.Add(item);
            }
            return View(newList);
        }

        // POST: Admin/Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        public async Task<IActionResult> EditNomre(int? id ,string SpecifiedName)
        {


   
            //var studentNomreViewModel = courseStudentRepository.GetCourseStudentById(id.Value , );
             var courseStudent =  courseStudentRepository.GetCourseStudentIdByStudentIdAndCoursId(id.Value, Convert.ToInt32(SpecifiedName));
            var myCoursStudent = courseStudentRepository.GetCourseStudentById(courseStudent);
            var student = studentRepository.GetStudentById(id.Value);
            var studentNomreViewModel = new StudentNomreViewModel()
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                NationalCode = student.NationalCode,
                UserName = student.UserName,
                Nomre = myCoursStudent.Nomre,
                CourseId = Convert.ToInt32(SpecifiedName)
            };



            if (studentNomreViewModel == null)
            {
                return NotFound();
            }

            return View(studentNomreViewModel);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNomre(int id, [Bind("Id,UserName,Name,Mob,Nomre,CourseId")] StudentNomreViewModel studentNomreViewModel)
        {
          
           
            if (id != studentNomreViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                int mycourseId;
                try
                {
                    int myStudentId = studentNomreViewModel.Id;
                     mycourseId = studentNomreViewModel.CourseId;
                    var updateId = courseStudentRepository.GetCourseStudentIdByStudentIdAndCoursId(myStudentId, mycourseId);
         
                    var myCoursStudent = new CourseStudent()
                    {
                        Id = updateId,
                        CourseId = mycourseId,
                        StudentId = myStudentId,
                        Nomre = studentNomreViewModel.Nomre
                    };
                    courseStudentRepository.UpdateCourseStudent(myCoursStudent);
                    courseStudentRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
            
                return RedirectToAction("Edit", new { id = mycourseId });

             //   return RedirectToAction(nameof(Index));
           
            }
            return View(studentNomreViewModel);
        }




    }
}
