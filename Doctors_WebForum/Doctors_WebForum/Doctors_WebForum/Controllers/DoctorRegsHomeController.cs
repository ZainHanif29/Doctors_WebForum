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
    public class DoctorRegsHomeController : Controller
    {
        private readonly Doctors_WebForumContext _context;

        public DoctorRegsHomeController(Doctors_WebForumContext context)
        {
            _context = context;
        }

        // GET: DoctorRegsHome
        public async Task<IActionResult> Index()
        {
            var doctors_WebForumContext = _context.DoctorRegs.Include(d => d.DExperienceNavigation).Include(d => d.DPrivacyNavigation).Include(d => d.DQualificationNavigation).Include(d => d.DSpecializationNavigation);
            return View(await doctors_WebForumContext.ToListAsync());
        }

        public async Task<IActionResult> doc()
        {
            var doctors_WebForumContext = _context.DoctorRegs.Include(d => d.DExperienceNavigation).Include(d => d.DPrivacyNavigation).Include(d => d.DQualificationNavigation).Include(d => d.DSpecializationNavigation);
            return View(await doctors_WebForumContext.ToListAsync());
        }

        // GET: DoctorRegsHome/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoctorRegs == null)
            {
                return NotFound();
            }

            var doctorReg = await _context.DoctorRegs
                .Include(d => d.DExperienceNavigation)
                .Include(d => d.DPrivacyNavigation)
                .Include(d => d.DQualificationNavigation)
                .Include(d => d.DSpecializationNavigation)
                .FirstOrDefaultAsync(m => m.DId == id);
            if (doctorReg == null)
            {
                return NotFound();
            }

            return View(doctorReg);
        }

        // GET: DoctorRegsHome/Create
        public IActionResult Create()
        {
            ViewData["DExperience"] = new SelectList(_context.Experiences, "EId", "EId");
            ViewData["DPrivacy"] = new SelectList(_context.Privacies, "PId", "PId");
            ViewData["DQualification"] = new SelectList(_context.Qualifications, "QId", "QId");
            ViewData["DSpecialization"] = new SelectList(_context.Specializations, "SId", "SId");
            return View();
        }

        // POST: DoctorRegsHome/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DId,DName,DEmail,DPassword,DContact,DAddress,DPrivacy,DQualification,DSpecialization,DExperience,DAchivement,DDesc")] DoctorReg doctorReg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorReg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DExperience"] = new SelectList(_context.Experiences, "EId", "EId", doctorReg.DExperience);
            ViewData["DPrivacy"] = new SelectList(_context.Privacies, "PId", "PId", doctorReg.DPrivacy);
            ViewData["DQualification"] = new SelectList(_context.Qualifications, "QId", "QId", doctorReg.DQualification);
            ViewData["DSpecialization"] = new SelectList(_context.Specializations, "SId", "SId", doctorReg.DSpecialization);
            return View(doctorReg);
        }

        // GET: DoctorRegsHome/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoctorRegs == null)
            {
                return NotFound();
            }

            var doctorReg = await _context.DoctorRegs.FindAsync(id);
            if (doctorReg == null)
            {
                return NotFound();
            }
            ViewData["DExperience"] = new SelectList(_context.Experiences, "EId", "EId", doctorReg.DExperience);
            ViewData["DPrivacy"] = new SelectList(_context.Privacies, "PId", "PId", doctorReg.DPrivacy);
            ViewData["DQualification"] = new SelectList(_context.Qualifications, "QId", "QId", doctorReg.DQualification);
            ViewData["DSpecialization"] = new SelectList(_context.Specializations, "SId", "SId", doctorReg.DSpecialization);
            return View(doctorReg);
        }

        // POST: DoctorRegsHome/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DId,DName,DEmail,DPassword,DContact,DAddress,DPrivacy,DQualification,DSpecialization,DExperience,DAchivement,DDesc")] DoctorReg doctorReg)
        {
            if (id != doctorReg.DId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorReg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorRegExists(doctorReg.DId))
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
            ViewData["DExperience"] = new SelectList(_context.Experiences, "EId", "EId", doctorReg.DExperience);
            ViewData["DPrivacy"] = new SelectList(_context.Privacies, "PId", "PId", doctorReg.DPrivacy);
            ViewData["DQualification"] = new SelectList(_context.Qualifications, "QId", "QId", doctorReg.DQualification);
            ViewData["DSpecialization"] = new SelectList(_context.Specializations, "SId", "SId", doctorReg.DSpecialization);
            return View(doctorReg);
        }

        // GET: DoctorRegsHome/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoctorRegs == null)
            {
                return NotFound();
            }

            var doctorReg = await _context.DoctorRegs
                .Include(d => d.DExperienceNavigation)
                .Include(d => d.DPrivacyNavigation)
                .Include(d => d.DQualificationNavigation)
                .Include(d => d.DSpecializationNavigation)
                .FirstOrDefaultAsync(m => m.DId == id);
            if (doctorReg == null)
            {
                return NotFound();
            }

            return View(doctorReg);
        }

        // POST: DoctorRegsHome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoctorRegs == null)
            {
                return Problem("Entity set 'Doctors_WebForumContext.DoctorRegs'  is null.");
            }
            var doctorReg = await _context.DoctorRegs.FindAsync(id);
            if (doctorReg != null)
            {
                _context.DoctorRegs.Remove(doctorReg);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorRegExists(int id)
        {
          return (_context.DoctorRegs?.Any(e => e.DId == id)).GetValueOrDefault();
        }
    }
}
