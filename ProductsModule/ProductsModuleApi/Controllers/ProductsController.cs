using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductModuleDataAccess.Interfaces;
using ProductModuleDataAccess.Models;
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
        private readonly IUserService _userService;

        public ProductsController(IProductsService products, IUserService userService)
        {
            _products = products;
            _userService = userService;
        }

        [HttpGet("allproducts")]
        [ProducesResponseType(typeof(IEnumerable<Products>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllProducts()
        {
            var allProducts = _products.GetAllProducts();            

            foreach (var product in allProducts)
            {
                var user = await _userService.GetById(product.userid);

                product.user = user;
            }

            return Ok(allProducts);
        }
    }
}
