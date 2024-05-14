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

namespace HamburgerMVC.Areas.YonetimPaneli.Controllers
{
	[Area("YonetimPaneli")]
	public class HamburgerController : Controller
	{
		private readonly BurgerDBContext _context;

		public HamburgerController(BurgerDBContext context)
		{
			_context = context;
		}

		// GET: YonetimPaneli/Hamburger
		public async Task<IActionResult> Index()
		{
			return View(await _context.Hamburgers.ToListAsync());
		}

		// GET: YonetimPaneli/Hamburger/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var hamburger = await _context.Hamburgers
				.Include(x => x.HamburgerEkMalzemes)
				.ThenInclude(x => x.EkMalzeme)
				.FirstOrDefaultAsync(m => m.HamburgerID == id);


			if (hamburger == null)
			{
				return NotFound();
			}

			return View(hamburger);
		}

		// GET: YonetimPaneli/Hamburger/Create
		public IActionResult Create()
		{

			Hamburger_VM vm = new Hamburger_VM();
			vm.EkMalzemeListesi = new SelectList(_context.EkMalzemes.ToList(), "EkMalzemeID", "EkMalzemeAdi");

			return View(vm);
		}

		// POST: YonetimPaneli/Hamburger/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Hamburger_VM vm)
		{

			Hamburger hamburger = new Hamburger();
			hamburger.HamburgerAdi = vm.Hamburger.HamburgerAdi;
			hamburger.HamburgerFiyat = vm.Hamburger.HamburgerFiyat;
			hamburger.Resim = vm.Hamburger.Resim;

			_context.Hamburgers.Add(hamburger);
			_context.SaveChanges();	

			foreach (int malzemeID in vm.SeciliEkMalzemelerID)
			{

				HamburgerEkMalzeme hamburgerEkMalzeme = new HamburgerEkMalzeme();

				hamburgerEkMalzeme.HamburgerID = hamburger.HamburgerID;
				hamburgerEkMalzeme.EkMalzemeID = malzemeID;

				_context.HamburgerEkMalzemes.Add(hamburgerEkMalzeme);
				_context.SaveChanges();

			}

			return RedirectToAction(nameof(Index));

		}

		// GET: YonetimPaneli/Hamburger/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var hamburger = await _context.Hamburgers.FindAsync(id);
			if (hamburger == null)
			{
				return NotFound();
			}
			return View(hamburger);
		}

		// POST: YonetimPaneli/Hamburger/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("HamburgerID,HamburgerAdi,HamburgerFiyat,Resim")] Hamburger hamburger)
		{
			if (id != hamburger.HamburgerID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(hamburger);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!HamburgerExists(hamburger.HamburgerID))
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
			return View(hamburger);
		}

		// GET: YonetimPaneli/Hamburger/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var hamburger = await _context.Hamburgers
				.FirstOrDefaultAsync(m => m.HamburgerID == id);
			if (hamburger == null)
			{
				return NotFound();
			}

			return View(hamburger);
		}

		// POST: YonetimPaneli/Hamburger/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var hamburger = await _context.Hamburgers.FindAsync(id);
			if (hamburger != null)
			{
				_context.Hamburgers.Remove(hamburger);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool HamburgerExists(int id)
		{
			return _context.Hamburgers.Any(e => e.HamburgerID == id);
		}
	}
}
