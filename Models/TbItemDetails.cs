using System.ComponentModel.DataAnnotations;

namespace LaptopShop.Models
{
    public class TbItemDetails
    {
        [Key]
        public int Id { get; set; }
        public int CatigoryId { get; set; }
        public int ItemId { get; set; }
        [Required(ErrorMessage = "please select CPU")]
        [StringLength(50)]
        public string? CPU { get; set; }
        [Required(ErrorMessage = "please select GPU")]
        [StringLength(50)]
        public string? GPU { get; set; }
        [Required(ErrorMessage = "please select Ram Size")]
        public int RamSize { get; set; }
        [Required(ErrorMessage = "please select HardDisk")]
        [StringLength(50)]
        public string? HardDisk { get; set; }
        [Required(ErrorMessage = "please enter screen size")]
        public decimal ScreenSize { get; set; }
        [Required(ErrorMessage = "please select operating system")]
        [StringLength(15)]
        public string? OperatingSystem { get; set; }
        public bool Active { get; set; }
        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
