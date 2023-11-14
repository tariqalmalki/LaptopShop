namespace LaptopShop.Models
{
    public class ItemsDetailVM
    {
        public List<TbCategories> TbCategories { get; set; }
        public List<TbItems> TbItems { get; set;}
        public List<TbItemDetails> ItemsDetails { get; set; }
        public TbItemDetails ItemDetail { get; set; }
    }
}
