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
    public class CSSystemsController : Controller
    {
        private readonly FinalProjectContext _context;

        public CSSystemsController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: CSSystems
        public async Task<IActionResult> Index()
        {
            var finalProjectContext = _context.CSSystems.Include(c => c.PrimaryUser);
            return View(await finalProjectContext.ToListAsync());
        }

        // GET: CSSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSSystem = await _context.CSSystems
                .Include(c => c.PrimaryUser)
                .FirstOrDefaultAsync(m => m.CSSystemID == id);
            if (cSSystem == null)
            {
                return NotFound();
            }

            return View(cSSystem);
        }

        // GET: CSSystems/Create
        public IActionResult Create()
        {
            ViewData["PrimaryUserID"] = new SelectList(_context.Professors, "ProfessorID", "ProfessorID");
            return View();
        }

        // POST: CSSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CSSystemID,Name,IPAddress,PrimaryUserID")] CSSystem cSSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cSSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PrimaryUserID"] = new SelectList(_context.Professors, "ProfessorID", "ProfessorID", cSSystem.PrimaryUserID);
            return View(cSSystem);
        }

        // GET: CSSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSSystem = await _context.CSSystems.FindAsync(id);
            if (cSSystem == null)
            {
                return NotFound();
            }
            ViewData["PrimaryUserID"] = new SelectList(_context.Professors, "ProfessorID", "ProfessorID", cSSystem.PrimaryUserID);
            return View(cSSystem);
        }

        // POST: CSSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CSSystemID,Name,IPAddress,PrimaryUserID")] CSSystem cSSystem)
        {
            if (id != cSSystem.CSSystemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cSSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CSSystemExists(cSSystem.CSSystemID))
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
            ViewData["PrimaryUserID"] = new SelectList(_context.Professors, "ProfessorID", "ProfessorID", cSSystem.PrimaryUserID);
            return View(cSSystem);
        }

        // GET: CSSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSSystem = await _context.CSSystems
                .Include(c => c.PrimaryUser)
                .FirstOrDefaultAsync(m => m.CSSystemID == id);
            if (cSSystem == null)
            {
                return NotFound();
            }

            return View(cSSystem);
        }

        // POST: CSSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cSSystem = await _context.CSSystems.FindAsync(id);
            _context.CSSystems.Remove(cSSystem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CSSystemExists(int id)
        {
            return _context.CSSystems.Any(e => e.CSSystemID == id);
        }
    }
}
