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
    public class EkMalzemesController : Controller
    {
        private readonly BurgerDBContext _context;

        public EkMalzemesController(BurgerDBContext context)
        {
            _context = context;
        }

        // GET: YonetimPaneli/EkMalzemes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EkMalzemes.ToListAsync());
        }

        // GET: YonetimPaneli/EkMalzemes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekMalzeme = await _context.EkMalzemes
                .FirstOrDefaultAsync(m => m.EkMalzemeID == id);
            if (ekMalzeme == null)
            {
                return NotFound();
            }

            return View(ekMalzeme);
        }

        // GET: YonetimPaneli/EkMalzemes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YonetimPaneli/EkMalzemes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EkMalzemeID,EkMalzemeAdi,EkMalzemeFiyat,Resim")] EkMalzeme ekMalzeme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ekMalzeme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ekMalzeme);
        }

        // GET: YonetimPaneli/EkMalzemes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekMalzeme = await _context.EkMalzemes.FindAsync(id);
            if (ekMalzeme == null)
            {
                return NotFound();
            }
            return View(ekMalzeme);
        }

        // POST: YonetimPaneli/EkMalzemes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EkMalzemeID,EkMalzemeAdi,EkMalzemeFiyat,Resim")] EkMalzeme ekMalzeme)
        {
            if (id != ekMalzeme.EkMalzemeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ekMalzeme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EkMalzemeExists(ekMalzeme.EkMalzemeID))
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
            return View(ekMalzeme);
        }

        // GET: YonetimPaneli/EkMalzemes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekMalzeme = await _context.EkMalzemes
                .FirstOrDefaultAsync(m => m.EkMalzemeID == id);
            if (ekMalzeme == null)
            {
                return NotFound();
            }

            return View(ekMalzeme);
        }

        // POST: YonetimPaneli/EkMalzemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ekMalzeme = await _context.EkMalzemes.FindAsync(id);
            if (ekMalzeme != null)
            {
                _context.EkMalzemes.Remove(ekMalzeme);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EkMalzemeExists(int id)
        {
            return _context.EkMalzemes.Any(e => e.EkMalzemeID == id);
        }
    }
}
