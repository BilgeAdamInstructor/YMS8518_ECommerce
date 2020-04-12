using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Entities
{
    public class Category : Abstracts.Entity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Children { get; set; }
    }
}