using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Infrastructure;
using System.Linq;
namespace Store.Pages
{
    public class CartModel : PageModel
    {

        private IRepository<Product> repository;
        public CartModel(IRepository<Product> repo , Cart SessionCart)
        {
            repository = repo;
            Cart = SessionCart;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(long Id, string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.Id == Id);
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(product, 1);
            //HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long Id,string returnUrl)
        {
            Cart.RemoveItem(Cart.CartLines.First(x => x.Product.Id == Id).Product);
            return RedirectToPage(new { returnUrl = returnUrl });   
        }
    }
}

