using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.Entities
{
    public class Log : Abstracts.Entity
    {
        [Required, MaxLength(150)]
        public string Controller { get; set; }
        
        [Required, MaxLength(150)]
        public string Action { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
        
        [Required, MaxLength(150)]
        public string IpAddress { get; set; }
    }
}