using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HamburgerMVC.DAL;
using HamburgerMVC.Models;

namespace HamburgerMVC.Areas.YonetimPaneli.Controllers
{
    [Area("YonetimPaneli")]
    public class YanUrunsController : Controller
    {
        private readonly BurgerDBContext _context;

        public YanUrunsController(BurgerDBContext context)
        {
            _context = context;
        }

        // GET: YonetimPaneli/YanUruns
        public async Task<IActionResult> Index()
        {
            return View(await _context.YanUruns.ToListAsync());
        }

        // GET: YonetimPaneli/YanUruns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yanUrun = await _context.YanUruns
                .FirstOrDefaultAsync(m => m.YanUrunID == id);
            if (yanUrun == null)
            {
                return NotFound();
            }

            return View(yanUrun);
        }

        // GET: YonetimPaneli/YanUruns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YonetimPaneli/YanUruns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YanUrunID,YanUrunAdi,YanUrunFiyat,Resim")] YanUrun yanUrun)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yanUrun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yanUrun);
        }

        // GET: YonetimPaneli/YanUruns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yanUrun = await _context.YanUruns.FindAsync(id);
            if (yanUrun == null)
            {
                return NotFound();
            }
            return View(yanUrun);
        }

        // POST: YonetimPaneli/YanUruns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YanUrunID,YanUrunAdi,YanUrunFiyat,Resim")] YanUrun yanUrun)
        {
            if (id != yanUrun.YanUrunID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yanUrun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YanUrunExists(yanUrun.YanUrunID))
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
            return View(yanUrun);
        }

        // GET: YonetimPaneli/YanUruns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yanUrun = await _context.YanUruns
                .FirstOrDefaultAsync(m => m.YanUrunID == id);
            if (yanUrun == null)
            {
                return NotFound();
            }

            return View(yanUrun);
        }

        // POST: YonetimPaneli/YanUruns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yanUrun = await _context.YanUruns.FindAsync(id);
            if (yanUrun != null)
            {
                _context.YanUruns.Remove(yanUrun);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YanUrunExists(int id)
        {
            return _context.YanUruns.Any(e => e.YanUrunID == id);
        }
    }
}
