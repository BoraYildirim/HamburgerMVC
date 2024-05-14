namespace HamburgerMVC.Models
{
    public class Hamburger
    {
        public int HamburgerID { get; set; }
        public string HamburgerAdi { get; set; }
        public decimal HamburgerFiyat { get; set; }
        public string? Resim { get; set; }

        public ICollection<HamburgerEkMalzeme>? HamburgerEkMalzemes { get; set; }
        public ICollection<Menu>? Menus { get; set; }
    }
}
