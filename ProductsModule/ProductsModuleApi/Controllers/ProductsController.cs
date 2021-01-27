using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductModuleDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsModuleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _products;

        public ProductsController(IProductsService products)
        {
            _products = products;
        }

        [HttpGet("allproducts")]
        public IActionResult GetAllProducts()
        {
            var allProducts = _products.GetAllProducts();

            return Ok(allProducts);
        }
    }
}
