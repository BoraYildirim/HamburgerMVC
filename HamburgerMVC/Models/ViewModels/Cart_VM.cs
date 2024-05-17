namespace HamburgerMVC.Models.ViewModels
{
    public class Cart_VM
    {
        public List<CartItem> CartItems { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
