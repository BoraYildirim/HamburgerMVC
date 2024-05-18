namespace HamburgerMVC.Models.ViewModels
{
    public class MenuEkle
    {
        public string MenuAdi { get; set; }
        public decimal MenuFiyat { get; set; }

        public int HamburgerID { get; set; }
        public int YanUrunID { get; set; }
        public int IcecekID { get; set; }
        public int BoyID { get; set; }

        public IFormFile ResimYolu { get; set; }
    }
}
