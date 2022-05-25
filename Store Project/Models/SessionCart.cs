using Store.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
namespace Store.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider session)
        {
            ISession Session = session?.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = Session?.GetJson<SessionCart>("cart") ?? new SessionCart();
            cart._Session = Session;
            return cart;

        }
        [JsonIgnore]
        public ISession _Session { get; set; }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            _Session.SetJson("cart", this);
        }

        public override void RemoveItem(Product product)
        {
            base.RemoveItem(product);
            _Session.SetJson("cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            _Session.Remove("cart");
        }

    }
}
