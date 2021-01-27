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
    public class TypesController : ControllerBase
    {
        private readonly ITypesService _types;

        public TypesController(ITypesService types)
        {
            _types = types;
        }

        [HttpGet("alltypes")]       
        public IActionResult GetAllTypes()
        {
            var allTypes = _types.GetAll();

            return Ok(allTypes);
        }
    }
}
