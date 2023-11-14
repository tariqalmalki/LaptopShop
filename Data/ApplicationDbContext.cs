using LaptopShop.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<TbCart> tbCart { get; set; }
        public DbSet<TbCategories> tbCategories  { get; set; }
        public DbSet<TbItems> tbItems { get; set; }
        public DbSet<TbItemDetails> tbItemDetails { get; set; }
        public DbSet<TbItemImages> tbItemImages { get; set; }
        public DbSet<TbInvoice> tbInvoice { get; set; }
    }
}
