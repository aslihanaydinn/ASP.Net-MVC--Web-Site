using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AltunkayaBurada.Models;
using Microsoft.Identity.Client;

namespace AltunkayaBurada.Controllers
{
    public class ConfytablesController : Controller
    {
        private readonly AltunkayadbContext _context;

        public ConfytablesController(AltunkayadbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Confytables != null ?
                        View(await _context.Confytables.ToListAsync()) :
                        Problem("Entity set 'AltunkayadbContext.Confytables'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Confytables == null)
            {
                return NotFound();
            }

            var confytable = await _context.Confytables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confytable == null)
            {
                return NotFound();
            }

            return View(confytable);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UrunAdi,EklenmeTarihi,SontuketimTarihi")] Confytable confytable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(confytable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(confytable);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Confytables == null)
            {
                return NotFound();
            }

            var confytable = await _context.Confytables.FindAsync(id);
            if (confytable == null)
            {
                return NotFound();
            }
            return View(confytable);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UrunAdi,EklenmeTarihi,SontuketimTarihi")] Confytable confytable)
        {
            if (id != confytable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confytable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfytableExists(confytable.Id))
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
            return View(confytable);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Confytables == null)
            {
                return NotFound();
            }

            var confytable = await _context.Confytables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confytable == null)
            {
                return NotFound();
            }

            return View(confytable);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Confytables == null)
            {
                return Problem("Entity set 'AltunkayadbContext.Confytables'  is null.");
            }
            var confytable = await _context.Confytables.FindAsync(id);
            if (confytable != null)
            {
                _context.Confytables.Remove(confytable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfytableExists(int id)
        {
            return (_context.Confytables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
