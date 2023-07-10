using AutoBiker.BackEnd_Apis.Services.Brands;
using AutoBiker.BackEnd_Apis.Services.Products;
using AutoBiker.Database.Entities;
using AutoBiker.ViewModel.Request.ProductRequest;
using AutoBiker.ViewModel.Resource;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoBiker.BackEnd_Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper, IBrandService brandService)
        {
            _productService = productService;
            _mapper = mapper;
            _brandService = brandService;
        } 
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.ListAsync();
            var result = _mapper.Map<List<Product>, List<ProductResource>>(products);
            return Ok(result);
        }
        [HttpGet("name/{keyword}")]
        public async Task<IActionResult> GetListByName(string keyword)
        {
            var products = await _productService.GetListByNameAsync(keyword);
            if (products == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<List<Product>, List<ProductResource>>(products);
            return Ok(result);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) {
                return NotFound();
            }
            var result = _mapper.Map<Product, ProductResource>(product);
            return Ok(result);

        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequest request)
        {
            if (!ModelState.IsValid)            
                return BadRequest(ModelState);

            var brandExist = await _brandService.GetBrandById(request.BrandId);
            if (brandExist == null) 
                return BadRequest($"Brand with id:{request.BrandId} does not exist");
            
            var product = _mapper.Map<ProductRequest , Product>(request);
            var result = await _productService.AddProductAsync(product);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            var productResource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductRequest request)    
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var brandExist = await _brandService.GetBrandById(request.BrandId);
            if (brandExist == null)
                return BadRequest($"Brand with id:{request.BrandId} does not exist");

            var product = _mapper.Map<ProductRequest, Product>(request);
            var result = await _productService.EditProductAsync(id,product);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            //var productResult = GetById(id).Result;
            var productResource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }
    }
}
