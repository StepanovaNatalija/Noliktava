using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Noliktava.Data;
using Noliktava.Models;

namespace Noliktava.Controllers
{
    public class PrecesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrecesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Preces
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prece.ToListAsync());
        }

        // GET: Preces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prece = await _context.Prece
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prece == null)
            {
                return NotFound();
            }

            return View(prece);
        }

        // GET: Preces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Preces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PrecKods,Nosaukums,PiegKods,Daudzums,Cena")] Prece prece)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prece);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prece);
        }

        // GET: Preces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prece = await _context.Prece.FindAsync(id);
            if (prece == null)
            {
                return NotFound();
            }
            return View(prece);
        }

        // POST: Preces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PrecKods,Nosaukums,PiegKods,Daudzums,Cena")] Prece prece)
        {
            if (id != prece.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prece);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreceExists(prece.Id))
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
            return View(prece);
        }

        // GET: Preces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prece = await _context.Prece
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prece == null)
            {
                return NotFound();
            }

            return View(prece);
        }

        // POST: Preces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prece = await _context.Prece.FindAsync(id);
            _context.Prece.Remove(prece);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreceExists(int id)
        {
            return _context.Prece.Any(e => e.Id == id);
        }
    }
}
