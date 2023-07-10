using System.ComponentModel.DataAnnotations;

namespace AutoBiker.ViewModel.Resource
{
    public class ProductResource
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }
        public string BrandName { get; set; }
    }
}

