namespace HamburgerMVC.Models
{
    public class Menu
    {
        public int MenuID { get; set; }
        public string MenuAdi { get; set; }
        public decimal MenuFiyat { get; set; }

        public int HamburgerID { get; set; }
        public int YanUrunID { get; set; }
        public int IcecekID { get; set; }
        public int BoyID { get; set; }

        public string? Resim { get; set; }

        public Hamburger? Hamburger { get; set; }
        public YanUrun? YanUrun { get; set; }
        public Icecek? Icecek { get; set; }
        public Boy? Boy { get; set; }


        public ICollection<SosMenu>? SosMenus { get; set; }
    }
}
