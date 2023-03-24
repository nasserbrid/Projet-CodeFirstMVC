using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirstMVC.Models;

namespace CodeFirstMVC.Controllers
{
    public class SalariesController : Controller
    {
        private readonly SalarieContext _context;

        public SalariesController(SalarieContext context)
        {
            _context = context;
        }

        // GET: Salaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salaries.ToListAsync());
        }

        // GET: Salaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salarie = await _context.Salaries
                .FirstOrDefaultAsync(m => m.Sal_ID == id);
            if (salarie == null)
            {
                return NotFound();
            }

            return View(salarie);
        }

        // GET: Salaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sal_ID,Sal_nom,Sal_age,Sal_description")] Salarie salarie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salarie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salarie);
        }

        // GET: Salaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salarie = await _context.Salaries.FindAsync(id);
            if (salarie == null)
            {
                return NotFound();
            }
            return View(salarie);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sal_ID,Sal_nom,Sal_age,Sal_description")] Salarie salarie)
        {
            if (id != salarie.Sal_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salarie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalarieExists(salarie.Sal_ID))
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
            return View(salarie);
        }

        // GET: Salaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salarie = await _context.Salaries
                .FirstOrDefaultAsync(m => m.Sal_ID == id);
            if (salarie == null)
            {
                return NotFound();
            }

            return View(salarie);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salarie = await _context.Salaries.FindAsync(id);
            _context.Salaries.Remove(salarie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalarieExists(int id)
        {
            return _context.Salaries.Any(e => e.Sal_ID == id);
        }
    }
}
