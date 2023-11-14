using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models
{
    public class TbItemImages
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "please upload image")]
        [StringLength(50)]
        public string? Path { get; set; }
        public bool Active { get; set; }
        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
