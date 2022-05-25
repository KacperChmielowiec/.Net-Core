namespace Store.Models
{
	public interface IRepository<T>
	{

		public IQueryable<T> Products { get; }

		void SaveProduct(Product p);
		void CreateProduct(Product p);
		void DeleteProduct(Product p);

	}
}
