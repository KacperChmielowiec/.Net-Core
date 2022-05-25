namespace Store.Models
{
	public class StoreRepository : IRepository<Product>
	{
		public StoreDbContext context;
		public StoreRepository(StoreDbContext _rep) => context = _rep;
		public IQueryable<Product> Products => context.products;

		public void CreateProduct(Product p)
		{
			context.Add(p);
			context.SaveChanges();
		}
		public void DeleteProduct(Product p)
		{
			context.Remove(p);
			context.SaveChanges();
		}
		public void SaveProduct(Product p)
		{
			context.SaveChanges();
		}

	}
}
