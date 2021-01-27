using ProductModuleDataAccess.Interfaces;
using ProductModuleDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductModuleDataAccess.Implementations
{
    public class ProductsService : IProductsService
    {
        private readonly ProducrModuleDbContext _dbContext;

        public ProductsService(ProducrModuleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Products> GetAllProducts()
        {
            var allProducts = _dbContext.products.ToList();

            return allProducts;
        }
    }
}
