///////////////////////////////////////////////////////////
///
/// Project: Final Project 
/// File Name: SoftwareController.cs
/// Description: Controls decision logic of Software pages 
/// Course: CSCI 2910-201
/// Author: Ben Higgins, higginsba@etsu.edu
/// Created: November 23, 2019
/// 
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.Controllers
{
    public class SoftwareController : Controller
    {
        private readonly FinalProjectContext _context;

        public SoftwareController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: Softwares
        public async Task<IActionResult> Index()
        {
            return View(await _context.Software.ToListAsync());
        }

        // GET: Softwares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var software = await _context.Software
                .Include(t => t.NeededBy)
                .FirstOrDefaultAsync(m => m.SoftwareID == id);

            var professors = await _context.Professors.ToListAsync();

            if (software == null)
            {
                return NotFound();
            }

            SoftwareProfessorsViewModel spViewModel = new SoftwareProfessorsViewModel
            {
                Software = software,
                Professors = professors
            };

            return View(spViewModel);
        }

        // POST: Software/Details
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detail(int id, int pId)
        {
            var software = _context.Software
                 .Include(t => t.NeededBy)
                 .Single(t => t.SoftwareID == id);

            var professor = _context.Professors.Single(p => p.ProfessorID == pId);

            software.NeededBy.Add(new ProfessorSoftware { Software = software, Professor = professor});

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                return View(e);
            }

            return Redirect($"/Software/Details/{id}");
        }

        [Route("/software/details/{id}/ProfessorDelete/{pId}")]
        public IActionResult ProfessorDelete(int id, int pId)
        {
            try
            {
                var software = _context.Software
                 .Include(s => s.NeededBy)
                 .Single(s => s.SoftwareID == id);

                var professors = _context.Professors.Single(p => p.ProfessorID== pId);

                software.NeededBy.Remove(software.NeededBy.Where(sp => sp.ProfessorID== pId).First());

                _context.SaveChanges();
            }
            catch (Exception e)
            {

                return View(e);
            }

            return Redirect($"/Software/Details/{id}");
        }

        // GET: Softwares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Softwares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoftwareID,Name,Version,URL,CSOnly")] Software software)
        {
            if (ModelState.IsValid)
            {
                _context.Add(software);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(software);
        }

        // GET: Softwares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var software = await _context.Software.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }
            return View(software);
        }

        // POST: Softwares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoftwareID,Name,Version,URL,CSOnly")] Software software)
        {
            if (id != software.SoftwareID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(software);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwareExists(software.SoftwareID))
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
            return View(software);
        }

        // GET: Softwares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var software = await _context.Software
                .FirstOrDefaultAsync(m => m.SoftwareID == id);
            if (software == null)
            {
                return NotFound();
            }

            return View(software);
        }

        // POST: Softwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var software = await _context.Software.FindAsync(id);
            _context.Software.Remove(software);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftwareExists(int id)
        {
            return _context.Software.Any(e => e.SoftwareID == id);
        }
    }
}
