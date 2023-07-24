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
    public class MahmoodtablesController : Controller
    {
        private readonly AltunkayadbContext _context;

        public MahmoodtablesController(AltunkayadbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Mahmoodtables != null ? 
                          View(await _context.Mahmoodtables.ToListAsync()) :
                          Problem("Entity set 'AltunkayadbContext.Mahmoodtables'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mahmoodtables == null)
            {
                return NotFound();
            }

            var mahmoodtable = await _context.Mahmoodtables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mahmoodtable == null)
            {
                return NotFound();
            }

            return View(mahmoodtable);
        }
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UrunAdi,EklenmeTarihi,SontuketimTarihi")] Mahmoodtable mahmoodtable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mahmoodtable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mahmoodtable);
        }

     
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mahmoodtables == null)
            {
                return NotFound();
            }

            var mahmoodtable = await _context.Mahmoodtables.FindAsync(id);
            if (mahmoodtable == null)
            {
                return NotFound();
            }
            return View(mahmoodtable);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UrunAdi,EklenmeTarihi,SontuketimTarihi")] Mahmoodtable mahmoodtable)
        {
            if (id != mahmoodtable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mahmoodtable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MahmoodtableExists(mahmoodtable.Id))
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
            return View(mahmoodtable);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mahmoodtables == null)
            {
                return NotFound();
            }

            var mahmoodtable = await _context.Mahmoodtables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mahmoodtable == null)
            {
                return NotFound();
            }

            return View(mahmoodtable);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mahmoodtables == null)
            {
                return Problem("Entity set 'AltunkayadbContext.Mahmoodtables'  is null.");
            }
            var mahmoodtable = await _context.Mahmoodtables.FindAsync(id);
            if (mahmoodtable != null)
            {
                _context.Mahmoodtables.Remove(mahmoodtable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MahmoodtableExists(int id)
        {
          return (_context.Mahmoodtables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
