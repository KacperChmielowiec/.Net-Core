using Microsoft.AspNetCore.Mvc;
namespace Store.Components
{
    public class NavView :  ViewComponent
    {

        IRepository<Product> _repository;
        public NavView(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.c = RouteData?.Values["category"];
            string s = ViewBag.c;
            return View(_repository.Products.
                Select(x => x.Category).Distinct().OrderBy(x => x));

        }
    }
}
