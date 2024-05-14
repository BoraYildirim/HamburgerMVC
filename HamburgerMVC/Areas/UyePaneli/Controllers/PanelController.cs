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
      
        public PanelController(UserManager<Uye> userManager)
        {
            _userManager = userManager;
        }
         
        public IActionResult Index()
        {           
            ViewBag.ID = GetUserID();         
            return View();
        }



        public int GetUserID()
        {
            //ctor injection ile UserManager'ı yükle...
            return int.Parse(_userManager.GetUserId(User));
        }
    }
}
