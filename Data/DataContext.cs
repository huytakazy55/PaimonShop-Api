using Microsoft.EntityFrameworkCore;

namespace PaimonShopApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<PaimonShop> PaimonShops { get; set;}
    }
}