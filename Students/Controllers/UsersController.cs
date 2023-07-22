using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students.Domain.Entities;
using Students.Persistence.DbContexts;
using Students.Services.Repositories;
using Students.Services.Service;

namespace Students.Controllers
{
    public class UsersController : Controller
    {
        private readonly StudentDbContext _context;
        private IUser userRepository;
        private ICI_Role cI_RoleRepository;
        public UsersController( IUser user,ICI_Role cI_Role)
        {
          
            userRepository = user;
            cI_RoleRepository = cI_Role;
        }


        public IActionResult Create()

        {
            ViewData["CI_RoleId"] = new SelectList(cI_RoleRepository.GetAllCI_Role(), "Id", "Title");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,CI_RoleId")] User user)
        {

           
            if (ModelState.IsValid)
            {
                if (userRepository.IsExistUser(user))
                {
                   // ViewBag.RepeatUserName = "نام کاربری انتخاب شده تکراری است ";
                    TempData["Message"] = "نام کاربری انتخاب شده تکراری است ";
                    return RedirectToAction("Create");
                }
                userRepository.AddUser(user);
                userRepository.save();      
                return RedirectToAction("PlzLogin");
          
            }
            ViewData["CI_RoleId"] = new SelectList(cI_RoleRepository.GetAllCI_Role(), "Id", "Title");
            return View(user);
        }

        public IActionResult PlzLogin()
        {
            TempData["alertMessage"] = "لطفا وارد شوید ";
            return View();
        }


        public IActionResult LogIn()
        {
            ViewData["CI_RoleId"] = new SelectList(cI_RoleRepository.GetAllCI_Role(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn([Bind("Id,UserName,CI_RoleId")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var Selectuser = userRepository.GetUserForLogin(user.UserName);
            if (Selectuser == null)
            {
                TempData["Message"] = "اطلاعات صحیح نیست";
                return View(user);
            }



            GlobalVariable.UserName = Selectuser.UserName;
            GlobalVariable.CI_RoleId = Selectuser.CI_RoleId;

            if (Selectuser.CI_RoleId == 1)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            if (Selectuser.CI_RoleId == 2)
            {
                return RedirectToAction("Index", "Home", new { area = "AreaTeacher" });
            }
            if (Selectuser.CI_RoleId == 3)
            {
                return RedirectToAction("Index", "Home", new { area = "AreaStudent" });
            }

            return View(user);

        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Create");
        }



    }
}
