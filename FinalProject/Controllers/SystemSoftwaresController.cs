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
    public class SystemSoftwaresController : Controller
    {
        private readonly FinalProjectContext _context;

        public SystemSoftwaresController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: SystemSoftwares
        public async Task<IActionResult> Index()
        {
            var finalProjectContext = _context.SystemSoftware.Include(s => s.CSSystem).Include(s => s.Software);
            return View(await finalProjectContext.ToListAsync());
        }

        // GET: SystemSoftwares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemSoftware = await _context.SystemSoftware
                .Include(s => s.CSSystem)
                .Include(s => s.Software)
                .FirstOrDefaultAsync(m => m.CSSystemID == id);
            if (systemSoftware == null)
            {
                return NotFound();
            }

            return View(systemSoftware);
        }

        // GET: SystemSoftwares/Create
        public IActionResult Create()
        {
            ViewData["CSSystemID"] = new SelectList(_context.CSSystems, "CSSystemID", "CSSystemID");
            ViewData["SoftwareID"] = new SelectList(_context.Software, "SoftwareID", "SoftwareID");
            return View();
        }

        // POST: SystemSoftwares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CSSystemID,SoftwareID")] SystemSoftware systemSoftware)
        {
            if (ModelState.IsValid)
            {
                _context.Add(systemSoftware);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CSSystemID"] = new SelectList(_context.CSSystems, "CSSystemID", "CSSystemID", systemSoftware.CSSystemID);
            ViewData["SoftwareID"] = new SelectList(_context.Software, "SoftwareID", "SoftwareID", systemSoftware.SoftwareID);
            return View(systemSoftware);
        }

        // GET: SystemSoftwares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemSoftware = await _context.SystemSoftware.FindAsync(id);
            if (systemSoftware == null)
            {
                return NotFound();
            }
            ViewData["CSSystemID"] = new SelectList(_context.CSSystems, "CSSystemID", "CSSystemID", systemSoftware.CSSystemID);
            ViewData["SoftwareID"] = new SelectList(_context.Software, "SoftwareID", "SoftwareID", systemSoftware.SoftwareID);
            return View(systemSoftware);
        }

        // POST: SystemSoftwares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CSSystemID,SoftwareID")] SystemSoftware systemSoftware)
        {
            if (id != systemSoftware.CSSystemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemSoftware);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemSoftwareExists(systemSoftware.CSSystemID))
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
            ViewData["CSSystemID"] = new SelectList(_context.CSSystems, "CSSystemID", "CSSystemID", systemSoftware.CSSystemID);
            ViewData["SoftwareID"] = new SelectList(_context.Software, "SoftwareID", "SoftwareID", systemSoftware.SoftwareID);
            return View(systemSoftware);
        }

        // GET: SystemSoftwares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemSoftware = await _context.SystemSoftware
                .Include(s => s.CSSystem)
                .Include(s => s.Software)
                .FirstOrDefaultAsync(m => m.CSSystemID == id);
            if (systemSoftware == null)
            {
                return NotFound();
            }

            return View(systemSoftware);
        }

        // POST: SystemSoftwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var systemSoftware = await _context.SystemSoftware.FindAsync(id);
            _context.SystemSoftware.Remove(systemSoftware);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemSoftwareExists(int id)
        {
            return _context.SystemSoftware.Any(e => e.CSSystemID == id);
        }
    }
}
