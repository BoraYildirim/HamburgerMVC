namespace HamburgerMVC.Models.ViewModels
{
    public class HamburgerGuncelle_VM
    {
        public Hamburger Hamburger { get; set; }
        public List<EkMalzeme> eList { get; set; }
        public List<int> ekMalzemelerID { get; set; }
    }
}
