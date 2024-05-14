using HamburgerMVC.Models.ViewModels;
using HamburgerMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerMVC.Controllers
{
    public class LoginController : Controller
    {


        private readonly SignInManager<Uye> _signInManager;
        private readonly UserManager<Uye> _userManager;

        public LoginController(SignInManager<Uye> signInManager, UserManager<Uye> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login_VM login)
        {
            var uye = _userManager.FindByEmailAsync(login.EMail).Result;

            if (uye == null)
            {
                //eposta kontrolu...
                ModelState.AddModelError("Hata", "Kullanıcı adı veya şifre yanlış...");
                return View();
            }

            if (!_userManager.CheckPasswordAsync(uye, login.Password).Result)
            {
                //sifre kontrolu...
                ModelState.AddModelError("Hata", "Kullanıcı adı veya şifre yanlış...");
                return View();
            }

            await _signInManager.SignInAsync(uye, false);

            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            //return Redirect("~/Home/Index");
            //return LocalRedirect("~/localhost:5168/Home/Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register_VM register)
        {
            //ModelState.ISValid() kontrol et...
            Uye uye = new Uye();
            uye.Adres = register.Address;
            uye.UserName = register.EMail;
            uye.Email = register.EMail;
            uye.Ad = register.Ad;
            uye.Soyad = register.Soyad;

            uye.PasswordHash = _userManager.PasswordHasher.HashPassword(uye, register.Password);
            var result = await _userManager.CreateAsync(uye);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(uye, "Uye");
                return RedirectToAction("Index", "Home");
            }

            return View();


        }

    }

}
