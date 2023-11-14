using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models
{
    public class TbCart
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
