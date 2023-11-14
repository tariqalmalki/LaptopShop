using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models
{
    public class TbInvoice
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "please enter price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "please enter tax")]
        public decimal Tax { get; set; }
        [Required(ErrorMessage = "please enter total")]
        public decimal Total { get; set; }
        [Required(ErrorMessage = "please enter net")]
        public decimal Net { get; set; }
        public bool Active { get; set; }
        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
