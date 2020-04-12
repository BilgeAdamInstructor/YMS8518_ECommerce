using System.Collections.Generic;

namespace ECommerce.Data.Entities
{
    public class Product : Abstracts.Entity
    {
        public string Name { get; set; }
        public int Sequence { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    }
}