using HamburgerMVC.DAL;
using HamburgerMVC.Models;
using HamburgerMVC.Models.ViewModels;
using HamburgerMVC.Oturum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Text;

namespace HamburgerMVC.Areas.UyePaneli.Controllers
{
    [Area("UyePaneli")]
    [Authorize(Roles = "Uye")]
    public class CartController : Controller
    {
        private readonly BurgerDBContext _context;

        public CartController(BurgerDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CartItem> items = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            Cart_VM cartvm = new Cart_VM()
            {
                CartItems = items,
                GrandTotal=items.Sum(x=>x.Adet*x.Fiyat)
            };

            return View(cartvm);
        }

        public async Task<IActionResult> Add(int id)
        {
            Menu menu = _context.Menus.Find(id);

            List<CartItem> items = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = items.FirstOrDefault(x => x.MenuID == id);

            if (cartItem == null)
            {
                items.Add(new CartItem(menu));
            }
            else
            {
                cartItem.Adet += 1;
            }
            HttpContext.Session.SetJson("Cart", items);
            TempData["Mesaj"] = "Ürün Sepete Eklenmiştir";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Decrease(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            CartItem cartItem = cart.Where(c => c.MenuID == id).FirstOrDefault();
            if (cartItem.Adet>1)
            {
                cartItem.Adet -= 1;
            }
            else 
            {
                cart.RemoveAll(c => c.MenuID == id);
            }
            if (cart.Count>0)
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["Mesaj"] = "Ürün Sepetten Silindi";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            cart.RemoveAll(c => c.MenuID == id);
            if (cart.Count>0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["Mesaj"] = "Ürün sepeti silindi";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Clear()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }
        
    }
}
