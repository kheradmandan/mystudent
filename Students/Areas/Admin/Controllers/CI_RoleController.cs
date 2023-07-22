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
    public class CI_RoleController : Controller
    {
        private readonly StudentDbContext _context;
        private ICI_Role cI_RoleRepository;
        public CI_RoleController(ICI_Role cI_Role )
        {
      
            cI_RoleRepository = cI_Role;
        }

        // GET: Admin/CI_Role
        public async Task<IActionResult> Index()
        {
            return View(cI_RoleRepository.GetAllCI_Role());
        }

        // GET: Admin/CI_Role/Details/5
        public async Task<IActionResult> Details(int? id)
        {


            var cI_Role = cI_RoleRepository.GetCI_RoleById(id.Value);
            if (cI_Role == null)
            {
                return NotFound();
            }

            return View(cI_Role);
        }

        // GET: Admin/CI_Role/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CI_Role/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] CI_Role cI_Role)
        {
            if (ModelState.IsValid)
            {
                cI_RoleRepository.InsertCI_Role(cI_Role);
                cI_RoleRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cI_Role);
        }

        // GET: Admin/CI_Role/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            var cI_Role = cI_RoleRepository.GetCI_RoleById(id.Value);

            if (cI_Role == null)
            {
                return NotFound();
            }
            return View(cI_Role);
        }

        // POST: Admin/CI_Role/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] CI_Role cI_Role)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    cI_RoleRepository.UpdateCI_Role(cI_Role);
                    cI_RoleRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            return View(cI_Role);
        }

        // GET: Admin/CI_Role/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {


            var cI_Role = cI_RoleRepository.GetCI_RoleById(id.Value);
            if (cI_Role == null)
            {
                return NotFound();
            }

            return View(cI_Role);
        }

        // POST: Admin/CI_Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var cI_Role = cI_RoleRepository.GetCI_RoleById(id);
            if (cI_Role != null)
            {
                cI_RoleRepository.DeleteCI_Role(cI_Role);
            }

            cI_RoleRepository.Save();
            return RedirectToAction(nameof(Index));
        }

    
    }
}
