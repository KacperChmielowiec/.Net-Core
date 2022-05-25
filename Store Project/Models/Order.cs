using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Store.Models
{
    
    public class Order
    {
        [BindNever]
        
        public int Id { get; set; }

        [BindNever]
        
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter first address line")]
        public string Line1 { get; set; } = "None";
        public string Line2 { get; set; } ="None";
        public string Line3 { get; set; } = "None";
        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a province")]
        public string Province { get; set; }
        [Required(ErrorMessage = "Please enter a code")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

        [BindNever]
        public bool Shipped { get; set; } = false;
        public bool GiftWrap { get; set; } = false;

    }
}
