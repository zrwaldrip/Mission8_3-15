using System.ComponentModel.DataAnnotations;

namespace Mission8_3_15.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }
    }
}