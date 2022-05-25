using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Store.Models
{
    public class Product
    {
      

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(8, 2)")]

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }

        public byte[] ?ImgProduct { get; set; }

    }
}
