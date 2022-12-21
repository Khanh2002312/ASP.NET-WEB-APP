using LT.NET_project_cuoiki.Entity;

namespace LT.NET_project_cuoiki.Models
{
    public class ProductInCart
    {
        private ProductEntity product;
        private int quantity;
        public ProductInCart() { }

        public ProductInCart(ProductEntity product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }

        public ProductEntity Product { get => product; set => product = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public void incrementQuantity()
        {
            this.quantity++;
        }
    }
}