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
    public class PrivaciesController : Controller
    {
        private readonly Doctors_WebForumContext _context;

        public PrivaciesController(Doctors_WebForumContext context)
        {
            _context = context;
        }

        // GET: Privacies
        public async Task<IActionResult> Index()
        {
              return _context.Privacies != null ? 
                          View(await _context.Privacies.ToListAsync()) :
                          Problem("Entity set 'Doctors_WebForumContext.Privacies'  is null.");
        }

        // GET: Privacies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Privacies == null)
            {
                return NotFound();
            }

            var privacy = await _context.Privacies
                .FirstOrDefaultAsync(m => m.PId == id);
            if (privacy == null)
            {
                return NotFound();
            }

            return View(privacy);
        }

        // GET: Privacies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Privacies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PId,PName")] Privacy privacy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(privacy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(privacy);
        }

        // GET: Privacies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Privacies == null)
            {
                return NotFound();
            }

            var privacy = await _context.Privacies.FindAsync(id);
            if (privacy == null)
            {
                return NotFound();
            }
            return View(privacy);
        }

        // POST: Privacies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PId,PName")] Privacy privacy)
        {
            if (id != privacy.PId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(privacy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrivacyExists(privacy.PId))
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
            return View(privacy);
        }

        // GET: Privacies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Privacies == null)
            {
                return NotFound();
            }

            var privacy = await _context.Privacies
                .FirstOrDefaultAsync(m => m.PId == id);
            if (privacy == null)
            {
                return NotFound();
            }

            return View(privacy);
        }

        // POST: Privacies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Privacies == null)
            {
                return Problem("Entity set 'Doctors_WebForumContext.Privacies'  is null.");
            }
            var privacy = await _context.Privacies.FindAsync(id);
            if (privacy != null)
            {
                _context.Privacies.Remove(privacy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrivacyExists(int id)
        {
          return (_context.Privacies?.Any(e => e.PId == id)).GetValueOrDefault();
        }
    }
}
