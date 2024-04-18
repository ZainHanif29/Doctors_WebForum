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
    public class UserRegsController : Controller
    {
        private readonly Doctors_WebForumContext _context;

        public UserRegsController(Doctors_WebForumContext context)
        {
            _context = context;
        }

        // GET: UserRegs
        public async Task<IActionResult> Index()
        {
              return _context.UserRegs != null ? 
                          View(await _context.UserRegs.ToListAsync()) :
                          Problem("Entity set 'Doctors_WebForumContext.UserRegs'  is null.");
        }

        // GET: UserRegs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserRegs == null)
            {
                return NotFound();
            }

            var userReg = await _context.UserRegs
                .FirstOrDefaultAsync(m => m.UId == id);
            if (userReg == null)
            {
                return NotFound();
            }

            return View(userReg);
        }

        // GET: UserRegs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserRegs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UId,UName,UEmail,UPassword,UContact,UAddress")] UserReg userReg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userReg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userReg);
        }

        // GET: UserRegs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserRegs == null)
            {
                return NotFound();
            }

            var userReg = await _context.UserRegs.FindAsync(id);
            if (userReg == null)
            {
                return NotFound();
            }
            return View(userReg);
        }

        // POST: UserRegs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UId,UName,UEmail,UPassword,UContact,UAddress")] UserReg userReg)
        {
            if (id != userReg.UId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userReg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRegExists(userReg.UId))
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
            return View(userReg);
        }

        // GET: UserRegs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserRegs == null)
            {
                return NotFound();
            }

            var userReg = await _context.UserRegs
                .FirstOrDefaultAsync(m => m.UId == id);
            if (userReg == null)
            {
                return NotFound();
            }

            return View(userReg);
        }

        // POST: UserRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserRegs == null)
            {
                return Problem("Entity set 'Doctors_WebForumContext.UserRegs'  is null.");
            }
            var userReg = await _context.UserRegs.FindAsync(id);
            if (userReg != null)
            {
                _context.UserRegs.Remove(userReg);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRegExists(int id)
        {
          return (_context.UserRegs?.Any(e => e.UId == id)).GetValueOrDefault();
        }
    }
}
