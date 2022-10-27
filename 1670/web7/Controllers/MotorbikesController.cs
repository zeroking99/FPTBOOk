using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web7.Data;
using web7.Models;

namespace web7.Controllers
{
    public class MotorbikesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MotorbikesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Motorbikes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Motorbike.ToListAsync());
        }

        // GET: Motorbikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorbike = await _context.Motorbike
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorbike == null)
            {
                return NotFound();
            }

            return View(motorbike);
        }

        // GET: Motorbikes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motorbikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Brand,Color,Price,Year")] Motorbike motorbike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motorbike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motorbike);
        }

        // GET: Motorbikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorbike = await _context.Motorbike.FindAsync(id);
            if (motorbike == null)
            {
                return NotFound();
            }
            return View(motorbike);
        }

        // POST: Motorbikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Brand,Color,Price,Year")] Motorbike motorbike)
        {
            if (id != motorbike.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorbike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorbikeExists(motorbike.Id))
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
            return View(motorbike);
        }

        // GET: Motorbikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorbike = await _context.Motorbike
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorbike == null)
            {
                return NotFound();
            }

            return View(motorbike);
        }

        // POST: Motorbikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motorbike = await _context.Motorbike.FindAsync(id);
            _context.Motorbike.Remove(motorbike);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotorbikeExists(int id)
        {
            return _context.Motorbike.Any(e => e.Id == id);
        }
    }
}
