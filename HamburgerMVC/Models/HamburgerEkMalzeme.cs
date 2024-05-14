namespace HamburgerMVC.Models
{
    public class HamburgerEkMalzeme
    {
        public int HamburgerEkMalzemeID { get; set; }
        public int HamburgerID { get; set; }
        public int EkMalzemeID { get; set; }
        public Hamburger? Hamburger { get; set; }
        public EkMalzeme? EkMalzeme { get; set; }
    }
}
