namespace HamburgerMVC.Models
{
    public class YanUrun
    {
        public int YanUrunID { get; set; }
        public string YanUrunAdi { get; set; }
        public decimal YanUrunFiyat { get; set; }
        public string? Resim { get; set; }

        public ICollection<Menu>? Menus { get; set; }
    }
}
