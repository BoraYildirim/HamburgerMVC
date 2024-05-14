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
    public class IceceksController : Controller
    {
        private readonly BurgerDBContext _context;

        public IceceksController(BurgerDBContext context)
        {
            _context = context;
        }

        // GET: YonetimPaneli/Iceceks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Iceceks.ToListAsync());
        }

        // GET: YonetimPaneli/Iceceks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icecek = await _context.Iceceks
                .FirstOrDefaultAsync(m => m.IcecekID == id);
            if (icecek == null)
            {
                return NotFound();
            }

            return View(icecek);
        }

        // GET: YonetimPaneli/Iceceks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YonetimPaneli/Iceceks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IcecekID,IcecekAdi,IcecekFiyat,Resim")] Icecek icecek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(icecek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(icecek);
        }

        // GET: YonetimPaneli/Iceceks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icecek = await _context.Iceceks.FindAsync(id);
            if (icecek == null)
            {
                return NotFound();
            }
            return View(icecek);
        }

        // POST: YonetimPaneli/Iceceks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IcecekID,IcecekAdi,IcecekFiyat,Resim")] Icecek icecek)
        {
            if (id != icecek.IcecekID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(icecek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IcecekExists(icecek.IcecekID))
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
            return View(icecek);
        }

        // GET: YonetimPaneli/Iceceks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icecek = await _context.Iceceks
                .FirstOrDefaultAsync(m => m.IcecekID == id);
            if (icecek == null)
            {
                return NotFound();
            }

            return View(icecek);
        }

        // POST: YonetimPaneli/Iceceks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var icecek = await _context.Iceceks.FindAsync(id);
            if (icecek != null)
            {
                _context.Iceceks.Remove(icecek);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IcecekExists(int id)
        {
            return _context.Iceceks.Any(e => e.IcecekID == id);
        }
    }
}
