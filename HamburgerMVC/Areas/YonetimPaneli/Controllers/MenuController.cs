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
    public class MenuController : Controller
    {
        private readonly BurgerDBContext _context;

        public MenuController(BurgerDBContext context)
        {
            _context = context;
        }

        // GET: YonetimPaneli/Menu
        public async Task<IActionResult> Index()
        {
            var burgerDBContext = _context.Menus.Include(m => m.Boy).Include(m => m.Hamburger).Include(m => m.Icecek).Include(m => m.YanUrun);
            return View(await burgerDBContext.ToListAsync());
        }

        // GET: YonetimPaneli/Menu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Boy)
                .Include(m => m.Hamburger)
                .Include(m => m.Icecek)
                .Include(m => m.YanUrun)
                .FirstOrDefaultAsync(m => m.MenuID == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: YonetimPaneli/Menu/Create
        public IActionResult Create()
        {
            ViewData["BoyID"] = new SelectList(_context.Boys, "BoyID", "BoyAdi");
            ViewData["HamburgerID"] = new SelectList(_context.Hamburgers, "HamburgerID", "HamburgerAdi");
            ViewData["IcecekID"] = new SelectList(_context.Iceceks, "IcecekID", "IcecekAdi");
            ViewData["YanUrunID"] = new SelectList(_context.YanUruns, "YanUrunID", "YanUrunAdi");
            return View();
        }

        // POST: YonetimPaneli/Menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuID,MenuAdi,MenuFiyat,HamburgerID,YanUrunID,IcecekID,BoyID,Resim")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoyID"] = new SelectList(_context.Boys, "BoyID", "BoyAdi", menu.BoyID);
            ViewData["HamburgerID"] = new SelectList(_context.Hamburgers, "HamburgerID", "HamburgerAdi", menu.HamburgerID);
            ViewData["IcecekID"] = new SelectList(_context.Iceceks, "IcecekID", "IcecekAdi", menu.IcecekID);
            ViewData["YanUrunID"] = new SelectList(_context.YanUruns, "YanUrunID", "YanUrunAdi", menu.YanUrunID);
            return View(menu);
        }

        // GET: YonetimPaneli/Menu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            ViewData["BoyID"] = new SelectList(_context.Boys, "BoyID", "BoyAdi", menu.BoyID);
            ViewData["HamburgerID"] = new SelectList(_context.Hamburgers, "HamburgerID", "HamburgerAdi", menu.HamburgerID);
            ViewData["IcecekID"] = new SelectList(_context.Iceceks, "IcecekID", "IcecekAdi", menu.IcecekID);
            ViewData["YanUrunID"] = new SelectList(_context.YanUruns, "YanUrunID", "YanUrunAdi", menu.YanUrunID);
            return View(menu);
        }

        // POST: YonetimPaneli/Menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuID,MenuAdi,MenuFiyat,HamburgerID,YanUrunID,IcecekID,BoyID,Resim")] Menu menu)
        {
            if (id != menu.MenuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.MenuID))
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
            ViewData["BoyID"] = new SelectList(_context.Boys, "BoyID", "BoyAdi", menu.BoyID);
            ViewData["HamburgerID"] = new SelectList(_context.Hamburgers, "HamburgerID", "HamburgerAdi", menu.HamburgerID);
            ViewData["IcecekID"] = new SelectList(_context.Iceceks, "IcecekID", "IcecekAdi", menu.IcecekID);
            ViewData["YanUrunID"] = new SelectList(_context.YanUruns, "YanUrunID", "YanUrunAdi", menu.YanUrunID);
            return View(menu);
        }

        // GET: YonetimPaneli/Menu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Boy)
                .Include(m => m.Hamburger)
                .Include(m => m.Icecek)
                .Include(m => m.YanUrun)
                .FirstOrDefaultAsync(m => m.MenuID == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: YonetimPaneli/Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.MenuID == id);
        }
    }
}
