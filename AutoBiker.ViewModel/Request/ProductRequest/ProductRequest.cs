using AutoBiker.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiker.ViewModel.Request.ProductRequest
{
    public class ProductRequest
    {
        [Display(Name = "Name Vehicle")]
        public string? Name { get; set; }
        [Display(Name = "Original Price")]
        public decimal OriginalPrice { get; set; }
        [Display(Name = "Current Price")]
        public decimal Price { get; set; }
        [Display(Name = "Quantity")]
        public int Stock { get; set; }
        [Display(Name = "Color Vehicle")]
        public string? Color { get; set; }
        [Display(Name = "Brand Id")]
        public string? BrandId { get; set; }
    }
}
