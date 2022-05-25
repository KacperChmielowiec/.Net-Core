using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _OrderRepository;
        private Cart cart;
        public OrderController(IOrderRepository rep, Cart cartService) { _OrderRepository = rep; cart = cartService; }
        [HttpGet]
        public ViewResult CheckOut()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            if (cart.CartLines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.CartLines.ToArray();
                _OrderRepository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Completed", new { Id = order.Id });
            }
            return View(order);
                
            
        }
    }
}
