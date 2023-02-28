using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capenexislearners2023.Data;
using Capenexislearners2023.Models;

namespace Capenexislearners2023.Controllers
{
    public class FacilitatorsController : Controller
    {
        private readonly Capenexislearners2023Context _context;

        public FacilitatorsController(Capenexislearners2023Context context)
        {
            _context = context;
        }

        // GET: Facilitators
        public async Task<IActionResult> Index(string searchString)
        {

            var facilitators = from m in _context.Facilitators
                               select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                facilitators = facilitators.Where(s => s.FacilitatorsName!.Contains(searchString) || s.FacilitatorsSurname!.Contains(searchString));
            }

            return View(await facilitators.ToListAsync());
        }

        // GET: Facilitators/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Facilitators == null)
            {
                return NotFound();
            }

            var facilitators = await _context.Facilitators
                .FirstOrDefaultAsync(m => m.FacilitatorsId == id);
            if (facilitators == null)
            {
                return NotFound();
            }

            return View(facilitators);
        }

        // GET: Facilitators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facilitators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacilitatorsId,FacilitatorsName,FacilitatorsSurname,FacilitatorsIdentityNumber")] Facilitators facilitators)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facilitators);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facilitators);
        }

        // GET: Facilitators/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Facilitators == null)
            {
                return NotFound();
            }

            var facilitators = await _context.Facilitators.FindAsync(id);
            if (facilitators == null)
            {
                return NotFound();
            }
            return View(facilitators);
        }

        // POST: Facilitators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("FacilitatorsId,FacilitatorsName,FacilitatorsSurname,FacilitatorsIdentityNumber")] Facilitators facilitators)
        {
            if (id != facilitators.FacilitatorsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facilitators);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilitatorsExists(facilitators.FacilitatorsId))
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
            return View(facilitators);
        }

        // GET: Facilitators/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Facilitators == null)
            {
                return NotFound();
            }

            var facilitators = await _context.Facilitators
                .FirstOrDefaultAsync(m => m.FacilitatorsId == id);
            if (facilitators == null)
            {
                return NotFound();
            }

            return View(facilitators);
        }

        // POST: Facilitators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Facilitators == null)
            {
                return Problem("Entity set 'Capenexislearners2023Context.Facilitators'  is null.");
            }
            var facilitators = await _context.Facilitators.FindAsync(id);
            if (facilitators != null)
            {
                _context.Facilitators.Remove(facilitators);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilitatorsExists(long id)
        {
          return (_context.Facilitators?.Any(e => e.FacilitatorsId == id)).GetValueOrDefault();
        }
    }
}
