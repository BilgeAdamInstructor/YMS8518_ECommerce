using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Entities
{
    public class Category : Abstracts.Entity
    {
        [Required, MinLength(1), MaxLength(200)]
        public string Name { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Category Parent { get; set; }

        public int? MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        
        public virtual ICollection<Category> Children { get; set; }
    }
}