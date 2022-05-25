namespace Store.Models
{
    public class StoreDbContext : DbContext
    {

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }

    }
}
