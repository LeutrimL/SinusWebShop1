namespace SinusWebShop.Client.Services
{
    public class ShoppingCartService
    {
        public List<CartItem> CartItems { get; } = new List<CartItem>();

        public void AddToCart(Product product)
        {
            CartItems.Add(new CartItem { Product = product });
        }

    }

    public class CartItem
    {
        public Product Product { get; set; }
    }
}
