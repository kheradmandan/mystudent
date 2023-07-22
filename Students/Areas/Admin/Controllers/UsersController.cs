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
    //new ViewResult { ViewName = "~/Views/Error/Unauthorised.cshtml" };
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly StudentDbContext _context;
        private IUser userRepository;
        private ICI_Role cI_RoleRepository;
        public UsersController( IUser user ,ICI_Role cI_Role )
        {
          
            userRepository = user;
            cI_RoleRepository = cI_Role;
        }

        // GET: Admin/Users
        public async Task<IActionResult> Index()
        {
         
            return View(userRepository.GetAllUsers());
        }

        // GET: Admin/Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {


            var user = userRepository.GetUserById(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Admin/Users/Create
        public IActionResult Create()
        {
            ViewData["CI_RoleId"] = new SelectList(cI_RoleRepository.GetAllCI_Role(), "Id", "Title");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,CI_RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                if (userRepository.IsExistUser(user))
                {
                    TempData["MessageTekrari"] = "نام کاربری انتخاب شده تکراری است ";
                    return RedirectToAction("Create");
                }
                userRepository.AddUser(user);
                userRepository.save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CI_RoleId"] = new SelectList(cI_RoleRepository.GetAllCI_Role(), "Id", "Title", user.CI_RoleId);
            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            var user = userRepository.GetUserById(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["CI_RoleId"] = new SelectList(cI_RoleRepository.GetAllCI_Role(), "Id", "Title", user.CI_RoleId);
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,CI_RoleId")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    userRepository.UpdateUser(user);
                    userRepository.save();
                }
                catch (DbUpdateConcurrencyException)
                {
                 
                        throw;
                 
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CI_RoleId"] = new SelectList(cI_RoleRepository.GetAllCI_Role(), "Id", "Title", user.CI_RoleId);
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {


            var user = userRepository.GetUserById(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var user = userRepository.GetUserById(id);
            if (user != null)
            {
                userRepository.DeleteUser(user);
            }

            userRepository.save();
            return RedirectToAction(nameof(Index));
        }

     
    }
}
