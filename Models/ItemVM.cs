namespace LaptopShop.Models
{
    public class ItemVM
    {
        public TbItems TbItem { get; set; }
        public IEnumerable<TbCategories> TbCategories { get; set; }
        public List<TbItems> TbItems { get; set; }
    }
}
