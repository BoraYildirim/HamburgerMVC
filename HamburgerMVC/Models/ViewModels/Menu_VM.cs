using Microsoft.AspNetCore.Mvc.Rendering;

namespace HamburgerMVC.Models.ViewModels
{
    public class Menu_VM
    {

        public MenuEkle? MenuEkle { get; set; }
        public Menu? Menu { get; set; }
        public List<Menu>? mlist { get; set; }

        public SelectList? Hamburger { get; set; }
        public SelectList? YanUrun { get; set; }
        public SelectList? Icecek { get; set; }
        public SelectList? Boy { get; set; }

    }
}
