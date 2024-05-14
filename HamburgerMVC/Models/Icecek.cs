namespace HamburgerMVC.Models
{
    public class Icecek
    {
        public int IcecekID { get; set; }
        public string IcecekAdi { get; set; }
        public decimal IcecekFiyat { get; set; }
        public string? Resim { get; set; }
        public ICollection<Menu>? Menus { get; set; }
    }
}
