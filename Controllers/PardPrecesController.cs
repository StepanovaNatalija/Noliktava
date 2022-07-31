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
    public class PardPrecesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PardPrecesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PardPreces
        public async Task<IActionResult> Index()
        {
            return View(await _context.PardPrece.ToListAsync());
        }

        // GET: PardPreces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pardPrece = await _context.PardPrece
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pardPrece == null)
            {
                return NotFound();
            }

            return View(pardPrece);
        }

        // GET: PardPreces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PardPreces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PrecKods,Datums,Skaits")] PardPrece pardPrece)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pardPrece);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pardPrece);
        }

        // GET: PardPreces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pardPrece = await _context.PardPrece.FindAsync(id);
            if (pardPrece == null)
            {
                return NotFound();
            }
            return View(pardPrece);
        }

        // POST: PardPreces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PrecKods,Datums,Skaits")] PardPrece pardPrece)
        {
            if (id != pardPrece.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pardPrece);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PardPreceExists(pardPrece.Id))
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
            return View(pardPrece);
        }

        // GET: PardPreces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pardPrece = await _context.PardPrece
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pardPrece == null)
            {
                return NotFound();
            }

            return View(pardPrece);
        }

        // POST: PardPreces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pardPrece = await _context.PardPrece.FindAsync(id);
            _context.PardPrece.Remove(pardPrece);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PardPreceExists(int id)
        {
            return _context.PardPrece.Any(e => e.Id == id);
        }
    }
}
