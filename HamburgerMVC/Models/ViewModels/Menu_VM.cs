namespace HamburgerMVC.Models.ViewModels
{
    public class Menu_VM
    {

        public Menu Menu { get; set; }
        public List<Menu> mlist { get; set; }

        public Hamburger? Hamburger { get; set; }
        public YanUrun? YanUrun { get; set; }
        public Icecek? Icecek { get; set; }



    }
}
