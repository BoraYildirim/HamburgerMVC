using Microsoft.AspNetCore.Mvc.Rendering;

namespace HamburgerMVC.Models.ViewModels
{
    public class Hamburger_VM
    {
        public Hamburger Hamburger { get; set; }
        public SelectList EkMalzemeListesi { get; set; }

        public List<int> SeciliEkMalzemelerID { get; set; }

        public Hamburger_VM()
        {
            SeciliEkMalzemelerID = new List<int>();
        }
    }
}
