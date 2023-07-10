using AutoBiker.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiker.ViewModel.ApiResult.ApiProductResult
{
    public class ProductResult : BaseResult
    {
        public Product Product { get; set; }
        public ProductResult(bool success, string message, Product product) : base(success, message) { }
        public ProductResult(Product product) : this(true, string.Empty, product)
        { }

        public ProductResult(string message) : this(false, message, null)
        { }
    }
}
