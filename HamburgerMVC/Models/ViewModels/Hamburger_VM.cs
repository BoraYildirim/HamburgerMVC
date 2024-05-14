using Microsoft.AspNetCore.Mvc.Rendering;

namespace HamburgerMVC.Models.ViewModels
{
    public class Hamburger_VM
    {
        public Hamburger Hamburger { get; set; }
        public SelectList elist { get; set; }
    }
}
