using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Store.Models
{
    public class Cart
    {
        public List<CartLine> CartLines { get; set; } = new List<CartLine>(); 
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = CartLines.FirstOrDefault(x => x.Product.Id == product.Id);
            if (line == null) CartLines.Add(new CartLine {Product = product, Quantity =quantity });
            else line.Quantity += quantity;

            
            
        }
        public virtual void RemoveItem(Product product) => CartLines.RemoveAll(x => x.Product.Id == product.Id);
        public virtual decimal ComputeTotalValue() => CartLines.Sum(x => x.Product.Price * x.Quantity);

        public virtual void Clear() => CartLines.Clear();

    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int CartLineID { get; set; }
    }
}
