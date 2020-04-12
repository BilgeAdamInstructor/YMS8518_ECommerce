using System.Collections.Generic;

namespace ECommerce.Data.Entities
{
    public class ShoppingCart : Abstracts.Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    }
}