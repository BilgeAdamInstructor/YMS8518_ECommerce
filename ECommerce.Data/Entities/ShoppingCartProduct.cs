namespace ECommerce.Data.Entities
{
    public class ShoppingCartProduct : Abstracts.Entity
    {
        public int ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}