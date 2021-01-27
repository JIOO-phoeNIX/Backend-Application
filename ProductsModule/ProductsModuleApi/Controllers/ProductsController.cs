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

        public ProductsController(IProductsService products)
        {
            _products = products;            
        }

        [HttpGet("allproducts")]
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Products>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllProducts()
        {
            var allProducts = await _products.GetAllProducts();                      

            return Ok(allProducts);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _products.GetById(id);

            if (product == null)
                return BadRequest($"Product with id : {id} doesn't exit");

            return Ok(product);
        }
    }
}
