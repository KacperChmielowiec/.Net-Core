using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Product> Repository;
        private IOrderRepository OrderRepository;
        int PageSize = 3;
        public HomeController(IRepository<Product> rep,IOrderRepository rep1)
        {
            Repository = rep;

            OrderRepository = rep1;
        }

        public ViewResult Index(string category, int productPage = 1)
          => View(new ViewInfoModel
          {
              Products = Repository.Products
                    .Where((p) => (p.Category == category || category == null))
                    .OrderBy(x => x.Id)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),

              CurrentCategory = category,
              _PagingInfo = new PagingInfo
              {
                  CurrentPage = productPage,
                  ItemsPerPage = PageSize,
                  TotalItem = category == null ? Repository.Products.Count() : Repository.Products.Where(x => x.Category == category).Count()
              }

          });
        
        public IActionResult Images(int id)
        {
            byte[] data = Repository.Products.Where(x => x.Id == id).Select(x => x.ImgProduct).FirstOrDefault();
            return File(data, "image/jpeg");
        }
        public ViewResult Temp()
        {
            return View(OrderRepository);
        }
    }
}
