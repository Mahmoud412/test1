using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SubgerneController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubgerneController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Subgernes.ToListAsync());
        }

        // GET: Subgenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subgenre = await _context.Subgernes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subgenre == null)
            {
                return NotFound();
            }

            return View(subgenre);
        }

        // GET: Subgenres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subgenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Subgerne subgenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subgenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subgenre);
        }

        // GET: Subgenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subgenre = await _context.Subgernes.FindAsync(id);
            if (subgenre == null)
            {
                return NotFound();
            }
            return View(subgenre);
        }

        // POST: Subgenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Subgerne subgenre)
        {
            if (id != subgenre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subgenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubgenreExists(subgenre.Id))
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
            return View(subgenre);
        }

        // GET: Subgenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subgenre = await _context.Subgernes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subgenre == null)
            {
                return NotFound();
            }

            return View(subgenre);
        }

        // POST: Subgenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subgenre = await _context.Subgernes.FindAsync(id);
            _context.Subgernes.Remove(subgenre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubgenreExists(int id)
        {
            return _context.Subgernes.Any(e => e.Id == id);
        }
    }

}
