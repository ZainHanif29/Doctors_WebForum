using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Doctors_WebForum.Models;

namespace Doctors_WebForum.Controllers
{
    public class AdminRegsController : Controller
    {
        private readonly Doctors_WebForumContext _context;

        public AdminRegsController(Doctors_WebForumContext context)
        {
            _context = context;
        }

        // GET: AdminRegs
        public async Task<IActionResult> Index()
        {
              return _context.AdminRegs != null ? 
                          View(await _context.AdminRegs.ToListAsync()) :
                          Problem("Entity set 'Doctors_WebForumContext.AdminRegs'  is null.");
        }

        // GET: AdminRegs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdminRegs == null)
            {
                return NotFound();
            }

            var adminReg = await _context.AdminRegs
                .FirstOrDefaultAsync(m => m.AId == id);
            if (adminReg == null)
            {
                return NotFound();
            }

            return View(adminReg);
        }

        // GET: AdminRegs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminRegs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AId,AName,AEmail,APassword")] AdminReg adminReg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminReg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminReg);
        }

        // GET: AdminRegs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdminRegs == null)
            {
                return NotFound();
            }

            var adminReg = await _context.AdminRegs.FindAsync(id);
            if (adminReg == null)
            {
                return NotFound();
            }
            return View(adminReg);
        }

        // POST: AdminRegs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AId,AName,AEmail,APassword")] AdminReg adminReg)
        {
            if (id != adminReg.AId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminReg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminRegExists(adminReg.AId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adminReg);
        }

        // GET: AdminRegs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdminRegs == null)
            {
                return NotFound();
            }

            var adminReg = await _context.AdminRegs
                .FirstOrDefaultAsync(m => m.AId == id);
            if (adminReg == null)
            {
                return NotFound();
            }

            return View(adminReg);
        }

        // POST: AdminRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdminRegs == null)
            {
                return Problem("Entity set 'Doctors_WebForumContext.AdminRegs'  is null.");
            }
            var adminReg = await _context.AdminRegs.FindAsync(id);
            if (adminReg != null)
            {
                _context.AdminRegs.Remove(adminReg);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminRegExists(int id)
        {
          return (_context.AdminRegs?.Any(e => e.AId == id)).GetValueOrDefault();
        }
    }
}
