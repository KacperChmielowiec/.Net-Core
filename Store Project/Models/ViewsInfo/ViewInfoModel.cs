namespace Store.Models.ViewsInfo
{
	public class ViewInfoModel
	{
		public PagingInfo _PagingInfo { get; set; }
		public IEnumerable<Product> Products { get; set; }
		public string CurrentCategory { get; set; }
	}
}
