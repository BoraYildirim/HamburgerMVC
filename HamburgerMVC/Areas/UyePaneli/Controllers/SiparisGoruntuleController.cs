using HamburgerMVC.DAL;
using HamburgerMVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HamburgerMVC.Areas.UyePaneli.Controllers
{
    [Area("UyePaneli")]
    [Authorize(Roles = "Uye")]
    public class SiparisGoruntuleController : Controller
    {

        private readonly BurgerDBContext db;

        public SiparisGoruntuleController(BurgerDBContext db)
        {
            this.db = db;
        }
        Menu_VM model = new Menu_VM();


        public IActionResult Index()
        {
            model.mlist=db.Menus.Include(x=>x.YanUrun).Include(x=>x.Icecek).Include(x=>x.Hamburger).Include(x=>x.Boy).ToList();

            return View(model);
        }
    }
}
