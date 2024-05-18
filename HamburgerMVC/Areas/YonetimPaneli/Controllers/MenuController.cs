using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HamburgerMVC.DAL;
using HamburgerMVC.Models;
using HamburgerMVC.Models.ViewModels;
using System.Drawing;

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
            Menu_VM vm = new Menu_VM();
            vm.Boy = new SelectList(_context.Boys.ToList(), "BoyID", "BoyAdi");
            vm.Hamburger = new SelectList(_context.Hamburgers.ToList(), "HamburgerID", "HamburgerAdi");
            vm.Icecek = new SelectList(_context.Iceceks.ToList(), "IcecekID", "IcecekAdi");
            vm.YanUrun = new SelectList(_context.YanUruns.ToList(), "YanUrunID", "YanUrunAdi");
            return View(vm);
        }

        // POST: YonetimPaneli/Menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(MenuEkle menuEkle)
        {


            if (ModelState.IsValid)
            {

                Menu menu = new Menu();
                menu.MenuAdi = menuEkle.MenuAdi;
                menu.BoyID = menuEkle.BoyID;
                menu.HamburgerID = menuEkle.HamburgerID;
                menu.IcecekID = menuEkle.IcecekID;
                menu.YanUrunID = menuEkle.YanUrunID;
                menu.MenuFiyat = menuEkle.MenuFiyat;



                Guid guid = Guid.NewGuid();
                string dosyaAdi = guid.ToString();
                dosyaAdi += menuEkle.ResimYolu.FileName;
                string dosyaYolu = "wwwroot/KapakResimleri/";
                menu.Resim = dosyaAdi;

                FileStream fs = new FileStream(dosyaYolu + dosyaAdi, FileMode.Create);
                menuEkle.ResimYolu.CopyTo(fs);
                fs.Close();




                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Menu_VM menuVM = new Menu_VM();
                menuVM.Boy = new SelectList(_context.Boys.ToList(), "BoyID", "BoyAdi");
                menuVM.Hamburger = new SelectList(_context.Hamburgers.ToList(), "HamburgerID", "HamburgerAdi");
                menuVM.Icecek = new SelectList(_context.Iceceks.ToList(), "IcecekID", "IcecekAdi");
                menuVM.YanUrun = new SelectList(_context.YanUruns.ToList(), "YanUrunID", "YanUrunAdi");

                return View(menuVM);
            }

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
