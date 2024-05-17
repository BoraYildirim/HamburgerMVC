using HamburgerMVC.DAL;
using HamburgerMVC.Models;
using HamburgerMVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HamburgerMVC.Areas.UyePaneli.Controllers
{

    [Area("UyePaneli")]
    [Authorize(Roles = "Uye")]
    public class PanelController : Controller
    {

        private readonly UserManager<Uye> _userManager;
        private readonly BurgerDBContext _context;

       

        public PanelController(UserManager<Uye> userManager, BurgerDBContext context)
        {
            _userManager = userManager;
            _context = context;
        }
         
        public IActionResult Index()
        {         
            ViewBag.ID = GetUserID();         
            return View();


        }


		public async Task<IActionResult> Details()
		{
            int id = GetUserID();
			if (id == null)
			{
				return NotFound();
			}

			var uye = await _context.Users
				.FirstOrDefaultAsync(m => m.Id == id);
			if (uye == null)
			{
				return NotFound();
			}

			return View(uye);
		}



		public int GetUserID()
        {
            //ctor injection ile UserManager'ı yükle...
            return int.Parse(_userManager.GetUserId(User));
        }

        public async Task<IActionResult> Edit()
        {
            int id = GetUserID();
            if (id == null)
            {
                return NotFound();
            }

            var uye = await _context.Users.FindAsync(id);
            if (uye == null)
            {
                return NotFound();
            }
            return View(uye);
        }

        // POST: UyePaneli/Uyes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ad,Soyad,Adres,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Uye uye)
        {
            if (id != uye.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uye);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                  
                }
                return RedirectToAction(nameof(Index));
            }
            return View(uye);
        }
    }
}
