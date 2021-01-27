using ProductModuleDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductModuleDataAccess.Interfaces
{
    public interface IProductsService
    {
        List<Products> GetAllProducts();
    }
}
