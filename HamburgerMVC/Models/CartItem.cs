namespace HamburgerMVC.Models
{
    public class CartItem
    {
        public long MenuID { get; set; }
        public string MenuAdi { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }

        public decimal Total
        {
            get { return Adet * Fiyat; }
        }
        public CartItem() { }
        public CartItem(Menu menu)
        {
            MenuID = menu.MenuID;
            MenuAdi = menu.MenuAdi;
            Adet = 1;
            Fiyat = menu.MenuFiyat;
        }
    }
}
