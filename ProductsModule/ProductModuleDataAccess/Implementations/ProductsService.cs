﻿using Microsoft.EntityFrameworkCore;
using ProductModuleDataAccess.Interfaces;
using ProductModuleDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModuleDataAccess.Implementations
{
    public class ProductsService : IProductsService
    {
        private readonly ProducrModuleDbContext _dbContext;
        private readonly IUserService _userService;

        public ProductsService(ProducrModuleDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<List<Products>> GetAllProducts()
        {
            var allProducts = _dbContext.products
                .Include(a => a.Type)
                .Include(a => a.Contact)
                .ToList();

            foreach (var product in allProducts)
            {
                var user = await _userService.GetById(product.userid);

                product.user = user;
            }

            return allProducts;
        }

        public async Task<Products> GetById(int id)
        {
            var product = _dbContext.products
                .Where(a => a.productsid == id)
                .Include(a => a.Type)
                .Include(a => a.Contact)
                .FirstOrDefault();

            if (product == null)
                return null;

            var user = await _userService.GetById(product.userid);

            product.user = user;

            return product;
        }
    }
}
