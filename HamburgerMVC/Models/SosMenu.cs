namespace HamburgerMVC.Models
{
    public class SosMenu
    {
        public int SosMenuID { get; set; }
        public int SosID { get; set; }
        public int MenuID { get; set; }
        public Sos? Sos { get; set; }
        public Menu? Menu { get; set; }
    }
}
