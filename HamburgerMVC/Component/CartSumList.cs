using HamburgerMVC.DAL;
using HamburgerMVC.Models;
using HamburgerMVC.Models.ViewModels;
using HamburgerMVC.Oturum;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerMVC.Component
{
    public class CartSumList:ViewComponent
    {
        private readonly BurgerDBContext _context;

        public CartSumList(BurgerDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            List<CartItem> items = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            Cart_VM cartvm = new Cart_VM()
            {
                CartItems = items,
                GrandTotal = items.Sum(x => x.Adet * x.Fiyat)
            };
            return View(cartvm);
        }
    }
}
