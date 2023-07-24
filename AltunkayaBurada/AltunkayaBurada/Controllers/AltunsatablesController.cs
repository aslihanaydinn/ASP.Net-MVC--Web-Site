using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AltunkayaBurada.Models;

namespace AltunkayaBurada.Controllers
{
    public class AltunsatablesController : Controller
    {
        private readonly AltunkayadbContext _context;

        public AltunsatablesController(AltunkayadbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
              return _context.Altunsatables != null ? 
                          View(await _context.Altunsatables.ToListAsync()) :
                          Problem("Entity set 'AltunkayadbContext.Altunsatables'  is null.");
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Altunsatables == null)
            {
                return NotFound();
            }

            var altunsatable = await _context.Altunsatables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (altunsatable == null)
            {
                return NotFound();
            }

            return View(altunsatable);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UrunAdi,EklenmeTarihi,SontuketimTarihi")] Altunsatable altunsatable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(altunsatable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(altunsatable);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Altunsatables == null)
            {
                return NotFound();
            }

            var altunsatable = await _context.Altunsatables.FindAsync(id);
            if (altunsatable == null)
            {
                return NotFound();
            }
            return View(altunsatable);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UrunAdi,EklenmeTarihi,SontuketimTarihi")] Altunsatable altunsatable)
        {
            if (id != altunsatable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(altunsatable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AltunsatableExists(altunsatable.Id))
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
            return View(altunsatable);
        }

      
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Altunsatables == null)
            {
                return NotFound();
            }

            var altunsatable = await _context.Altunsatables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (altunsatable == null)
            {
                return NotFound();
            }

            return View(altunsatable);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Altunsatables == null)
            {
                return Problem("Entity set 'AltunkayadbContext.Altunsatables'  is null.");
            }
            var altunsatable = await _context.Altunsatables.FindAsync(id);
            if (altunsatable != null)
            {
                _context.Altunsatables.Remove(altunsatable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AltunsatableExists(int id)
        {
          return (_context.Altunsatables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
