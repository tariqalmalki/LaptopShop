using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models
{
    public class TbItems
    {
        [Key] 
        public int Id { get; set; }
        public int CatigoryId { get; set; }
        [Required(ErrorMessage = "please enter item name")]
        [StringLength(50)]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "please enter price")]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        [Required(ErrorMessage = "please upload image")]
        [StringLength(50)]
        public string? Image { get; set; }
        public bool Active { get; set; }
        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
