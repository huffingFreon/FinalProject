using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class ProfessorSoftwaresController : Controller
    {
        private readonly FinalProjectContext _context;

        public ProfessorSoftwaresController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: ProfessorSoftwares
        public async Task<IActionResult> Index()
        {
            var finalProjectContext = _context.ProfessorSoftware.Include(p => p.Professor).Include(p => p.Software);
            return View(await finalProjectContext.ToListAsync());
        }

        // GET: ProfessorSoftwares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorSoftware = await _context.ProfessorSoftware
                .Include(p => p.Professor)
                .Include(p => p.Software)
                .FirstOrDefaultAsync(m => m.ProfessorID == id);
            if (professorSoftware == null)
            {
                return NotFound();
            }

            return View(professorSoftware);
        }

        // GET: ProfessorSoftwares/Create
        public IActionResult Create()
        {
            ViewData["ProfessorID"] = new SelectList(_context.Professors, "ProfessorID", "ProfessorID");
            ViewData["SoftwareID"] = new SelectList(_context.Software, "SoftwareID", "SoftwareID");
            return View();
        }

        // POST: ProfessorSoftwares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessorID,SoftwareID")] ProfessorSoftware professorSoftware)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professorSoftware);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfessorID"] = new SelectList(_context.Professors, "ProfessorID", "ProfessorID", professorSoftware.ProfessorID);
            ViewData["SoftwareID"] = new SelectList(_context.Software, "SoftwareID", "SoftwareID", professorSoftware.SoftwareID);
            return View(professorSoftware);
        }

        // GET: ProfessorSoftwares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorSoftware = await _context.ProfessorSoftware.FindAsync(id);
            if (professorSoftware == null)
            {
                return NotFound();
            }
            ViewData["ProfessorID"] = new SelectList(_context.Professors, "ProfessorID", "ProfessorID", professorSoftware.ProfessorID);
            ViewData["SoftwareID"] = new SelectList(_context.Software, "SoftwareID", "SoftwareID", professorSoftware.SoftwareID);
            return View(professorSoftware);
        }

        // POST: ProfessorSoftwares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessorID,SoftwareID")] ProfessorSoftware professorSoftware)
        {
            if (id != professorSoftware.ProfessorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professorSoftware);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorSoftwareExists(professorSoftware.ProfessorID))
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
            ViewData["ProfessorID"] = new SelectList(_context.Professors, "ProfessorID", "ProfessorID", professorSoftware.ProfessorID);
            ViewData["SoftwareID"] = new SelectList(_context.Software, "SoftwareID", "SoftwareID", professorSoftware.SoftwareID);
            return View(professorSoftware);
        }

        // GET: ProfessorSoftwares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorSoftware = await _context.ProfessorSoftware
                .Include(p => p.Professor)
                .Include(p => p.Software)
                .FirstOrDefaultAsync(m => m.ProfessorID == id);
            if (professorSoftware == null)
            {
                return NotFound();
            }

            return View(professorSoftware);
        }

        // POST: ProfessorSoftwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professorSoftware = await _context.ProfessorSoftware.FindAsync(id);
            _context.ProfessorSoftware.Remove(professorSoftware);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorSoftwareExists(int id)
        {
            return _context.ProfessorSoftware.Any(e => e.ProfessorID == id);
        }
    }
}
