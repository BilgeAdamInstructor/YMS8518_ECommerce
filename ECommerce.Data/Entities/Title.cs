using System.Collections.Generic;

namespace ECommerce.Data.Entities
{
    public class Title : Abstracts.Entity
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}