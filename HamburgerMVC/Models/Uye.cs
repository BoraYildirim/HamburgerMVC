using Microsoft.AspNetCore.Identity;

namespace HamburgerMVC.Models
{
    public class Uye:IdentityUser<int>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }

       
    }
}
