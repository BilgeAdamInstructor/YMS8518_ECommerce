using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.DTO
{
    public class Category_Save_Request
    {
        [Required, MinLength(1), MaxLength(200)]
        public string Name { get; set; }

        public int? MenuId { get; set; }
        public int? ParentCategoryId { get; set; }
        public int CategoryId { get; set; }
    }
}