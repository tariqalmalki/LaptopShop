using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LaptopShop.Models
{
    public class ItemsDetailVM
    {
        [ValidateNever]
        public List<TbCategories> TbCategories { get; set; }
        [ValidateNever]
        public List<TbItems> TbItems { get; set;}
        [ValidateNever]
        public List<TbItemDetails> ItemsDetails { get; set; }
        public TbItemDetails ItemDetail { get; set; }
    }
}
