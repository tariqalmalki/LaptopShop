using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LaptopShop.Models
{
    public class ItemVM
    {
        public TbItems TbItem { get; set; }
        [ValidateNever]
        public IEnumerable<TbCategories> TbCategories { get; set; }
        [ValidateNever]
        public List<TbItems> TbItems { get; set; }
    }
}
