using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models
{
    public class TbItems
    {
        [Key] 
        public int Id { get; set; }
        [Required(ErrorMessage = "please select Trade Mark")]
        public int CatigoryId { get; set; }
        [Required(ErrorMessage = "please enter item name")]
        [StringLength(50)]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "please enter price")]
        [Range(1,100000)]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        [StringLength(50)]
        public string? Image { get; set; }
        public bool Active { get; set; }
        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
