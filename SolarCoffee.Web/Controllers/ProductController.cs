using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Data.Models;
using SolarCoffee.Services.Product;
using SolarCoffee.Web.Serialization;
using System;
using System.Linq;

namespace SolarCoffee.Web.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        public ProductController(ILogger<ProductController> logger, 
            IProductService productService)
        {
            _logger = logger;
            _productService = productService; 
        }

        [HttpGet("/api/product")]
        public ActionResult GetProduct()
        {
            _logger.LogInformation("Getting all products");
            var products = _productService.GetAllProducts();

            //var productViewModels = products.Select(product => ProductMapper.SerializeProductModel(product))
            //shorthand of the above:
            var productViewModel = products
                .Select(ProductMapper.SerializeProductModel);

            return Ok(productViewModel);
        }

        [HttpPatch("/api/product/{id}")]
        public ActionResult ArchiveProduct(int id)
        {
            _logger.LogInformation("Archiving product");
            var archiveResult = _productService.ArchiveProduct(id);
            return Ok(archiveResult);
        }

        [HttpPost("/api/product")]
        public ActionResult CreateCustomer([FromBody] Product product)
        {
            _logger.LogInformation("Creating a new customer");
            product.CreatedOn = DateTime.UtcNow;
            product.UpdatedOn = DateTime.UtcNow;

            _productService.CreateProduct(product);

            return Ok(product);
        }
    }
}
