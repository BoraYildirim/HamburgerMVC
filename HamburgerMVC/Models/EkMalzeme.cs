namespace HamburgerMVC.Models
{
    public class EkMalzeme
    {
        public int EkMalzemeID { get; set; }
        public string EkMalzemeAdi { get; set; }
        public decimal EkMalzemeFiyat { get; set; }
        public string? Resim { get; set; }

        public ICollection<HamburgerEkMalzeme>? HamburgerEkMalzemes { get; set; }
    }
}
