using System.Reflection.PortableExecutable;

namespace HamburgerMVC.Models
{
    public class Sos
    {
        public int SosID { get; set; }
        public string SosAdi { get; set; }
        public decimal SosFiyat { get; set; }

        public ICollection<SosMenu>? SosMenus { get; set; }
    }
}
