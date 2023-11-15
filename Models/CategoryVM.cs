using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LaptopShop.Models
{
    public class CategoryVM
    {
        public TbCategories Category { get; set; }
        [ValidateNever]
        public List<TbCategories> Categories { get; set; }
    }
}
