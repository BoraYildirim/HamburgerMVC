namespace HamburgerMVC.Models
{
    public class Boy
    {
        public int BoyID { get; set; }
        public double BoyCarpani { get; set; }
        public string BoyAdi { get; set; }

        public ICollection<Menu>? Menus { get; set; }
    }
}
