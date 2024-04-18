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
    public class DoctorAppointmentsController : Controller
    {
        private readonly Doctors_WebForumContext _context;

        public DoctorAppointmentsController(Doctors_WebForumContext context)
        {
            _context = context;
        }

        // GET: DoctorAppointments
        public async Task<IActionResult> Index()
        {
            var doctors_WebForumContext = _context.DoctorAppointments.Include(d => d.ApSpecializationNavigation).Include(d => d.DIdNavigation);
            return View(await doctors_WebForumContext.ToListAsync());
        }

        // GET: DoctorAppointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoctorAppointments == null)
            {
                return NotFound();
            }

            var doctorAppointment = await _context.DoctorAppointments
                .Include(d => d.ApSpecializationNavigation)
                .Include(d => d.DIdNavigation)
                .FirstOrDefaultAsync(m => m.ApId == id);
            if (doctorAppointment == null)
            {
                return NotFound();
            }

            return View(doctorAppointment);
        }

        // GET: DoctorAppointments/Create
        public IActionResult Create()
        {
            ViewData["ApSpecialization"] = new SelectList(_context.Specializations, "SId", "SName");
            ViewData["DId"] = new SelectList(_context.DoctorRegs, "DId", "DName");
            return View();
        }

        // POST: DoctorAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApId,ApName,ApEmail,ApPhone,ApDate,ApSpecialization,DId,ApMsg")] DoctorAppointment doctorAppointment)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(doctorAppointment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index" , "DoctorRegsHome");
            }
            ViewData["ApSpecialization"] = new SelectList(_context.Specializations, "SId", "SId", doctorAppointment.ApSpecialization);
            ViewData["DId"] = new SelectList(_context.DoctorRegs, "DId", "DId", doctorAppointment.DId);
            return View(doctorAppointment);
        }

        // GET: DoctorAppointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoctorAppointments == null)
            {
                return NotFound();
            }

            var doctorAppointment = await _context.DoctorAppointments.FindAsync(id);
            if (doctorAppointment == null)
            {
                return NotFound();
            }
            ViewData["ApSpecialization"] = new SelectList(_context.Specializations, "SId", "SId", doctorAppointment.ApSpecialization);
            ViewData["DId"] = new SelectList(_context.DoctorRegs, "DId", "DId", doctorAppointment.DId);
            return View(doctorAppointment);
        }

        // POST: DoctorAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApId,ApName,ApEmail,ApPhone,ApDate,ApSpecialization,DId,ApMsg")] DoctorAppointment doctorAppointment)
        {
            if (id != doctorAppointment.ApId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorAppointmentExists(doctorAppointment.ApId))
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
            ViewData["ApSpecialization"] = new SelectList(_context.Specializations, "SId", "SId", doctorAppointment.ApSpecialization);
            ViewData["DId"] = new SelectList(_context.DoctorRegs, "DId", "DId", doctorAppointment.DId);
            return View(doctorAppointment);
        }

        // GET: DoctorAppointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoctorAppointments == null)
            {
                return NotFound();
            }

            var doctorAppointment = await _context.DoctorAppointments
                .Include(d => d.ApSpecializationNavigation)
                .Include(d => d.DIdNavigation)
                .FirstOrDefaultAsync(m => m.ApId == id);
            if (doctorAppointment == null)
            {
                return NotFound();
            }

            return View(doctorAppointment);
        }

        // POST: DoctorAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoctorAppointments == null)
            {
                return Problem("Entity set 'Doctors_WebForumContext.DoctorAppointments'  is null.");
            }
            var doctorAppointment = await _context.DoctorAppointments.FindAsync(id);
            if (doctorAppointment != null)
            {
                _context.DoctorAppointments.Remove(doctorAppointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorAppointmentExists(int id)
        {
          return (_context.DoctorAppointments?.Any(e => e.ApId == id)).GetValueOrDefault();
        }
    }
}
