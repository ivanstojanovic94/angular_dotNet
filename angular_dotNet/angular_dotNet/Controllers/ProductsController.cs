using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angular_dotNet.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "this will be a list of products";
        }

        [HttpGet("{id}")]
        public string GetProduct(byte id)
        {
            return $"this will be some product {id}";
        }

    }
}
