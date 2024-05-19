using HamburgerMVC.DAL;
using HamburgerMVC.Models;
using HamburgerMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HamburgerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BurgerDBContext _context;

        public HomeController(ILogger<HomeController> logger, BurgerDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            UrunListesi_VM vm = new UrunListesi_VM();

            vm.Hamburgerler = _context.Hamburgers.ToList();
            vm.Menuler = _context.Menus.ToList();
            vm.EkMalzemeler = _context.EkMalzemes.ToList();

            return View(vm);
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        public IActionResult Urunlerimiz()
        {
			UrunListesi_VM vm = new UrunListesi_VM();

			vm.Hamburgerler = _context.Hamburgers.ToList();
			vm.Menuler = _context.Menus.ToList();
			vm.EkMalzemeler = _context.EkMalzemes.ToList();

			return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
