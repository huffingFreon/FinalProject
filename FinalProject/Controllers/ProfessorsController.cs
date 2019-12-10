///////////////////////////////////////////////////////////
///
/// Project: Final Project 
/// File Name: ProfessorsController.cs
/// Description: Controls decision logic of Professor pages 
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
    public class ProfessorsController : Controller
    {
        private readonly FinalProjectContext _context;

        public ProfessorsController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: Professors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Professors.ToListAsync());
        }

        // GET: Professors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professors
                .Include(t => t.NeededSoftware)
                .Include(t => t.CheckedOutItems)
                .FirstOrDefaultAsync(m => m.ProfessorID == id);

            var software = await _context.Software.ToListAsync();

            var items = await _context.InventoryItems.ToListAsync();

            if (professor == null)
            {
                return NotFound();
            }

            ProfessorSoftwareViewModel psViewModel = new ProfessorSoftwareViewModel
            {
                Professor = professor,
                Softwares = software,
                InventoryItems = items
            };

            return View(psViewModel);
        }

        // POST: Professors/AddSoftware
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSoftware(int id, int sId)
        {
            var professor = _context.Professors
                 .Include(t => t.NeededSoftware)
                 .Single(t => t.ProfessorID== id);

            var software = _context.Software.Single(s => s.SoftwareID == sId);

            professor.NeededSoftware.Add(new ProfessorSoftware { Professor = professor, Software = software});

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                return View(e);
            }

            return Redirect($"/Professors/Details/{id}");
        }

        // POST: Professors/AddItem
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddItem(int id, int iId)
        {
            var professor = _context.Professors
                 .Include(t => t.CheckedOutItems)
                 .Single(t => t.ProfessorID == id);

            var inventoryItem = _context.InventoryItems.Single(i => i.InventoryItemID == iId);

            //Marks items as checked out when added to a Professor
            inventoryItem.CheckedOut = true;

            professor.CheckedOutItems.Add(inventoryItem);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                return View(e);
            }

            return Redirect($"/Professors/Details/{id}");
        }

        [Route("/professors/details/{id}/SoftwareDelete/{sId}")]
        public IActionResult SoftwareDelete(int id, int sId)
        {
            try
            {
                var professor = _context.Professors
                 .Include(p => p.NeededSoftware)
                 .Single(p => p.ProfessorID == id);

                var software = _context.Software.Single(s => s.SoftwareID == sId);

                professor.NeededSoftware.Remove(professor.NeededSoftware.Where(ps => ps.SoftwareID == sId).First());


                _context.SaveChanges();
            }
            catch (Exception e)
            {

                return View(e);
            }


            return Redirect($"/Professors/Details/{id}");
        }

        [Route("/professors/details/{id}/ItemDelete/{iId}")]
        public IActionResult ItemDelete(int id, int iId)
        {
            try
            {
                var professor = _context.Professors
                 .Include(p => p.CheckedOutItems)
                 .Single(p => p.ProfessorID == id);

                var inventoryItem = _context.InventoryItems.Single(p => p.InventoryItemID == iId);

                //Unmarks items as checked out when removed from a professor
                inventoryItem.CheckedOut = false;

                professor.CheckedOutItems.Remove(inventoryItem);

                _context.SaveChanges();
            }
            catch (Exception e)
            {

                return View(e);
            }

            return Redirect($"/Professors/Details/{id}");
        }

        // GET: Professors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessorID,Name,Email,PhoneNumber")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professors.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessorID,Name,Email,PhoneNumber")] Professor professor)
        {
            if (id != professor.ProfessorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.ProfessorID))
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
            return View(professor);
        }

        // GET: Professors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professors
                .FirstOrDefaultAsync(m => m.ProfessorID == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professors.FindAsync(id);
            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professors.Any(e => e.ProfessorID == id);
        }
    }
}
