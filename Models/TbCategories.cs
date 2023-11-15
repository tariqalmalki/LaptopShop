using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models
{
    public class TbCategories
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "please enter category name")]
        [StringLength(20)]
        public string? Name { get; set; }
        
        [StringLength(50)]
        public string? Image { get; set; }
        public bool Active { get; set; }
        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
