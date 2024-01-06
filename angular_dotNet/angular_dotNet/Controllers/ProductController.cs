using angular_dotNet.Data;
using angular_dotNet.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angular_dotNet.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _context;
        

        public ProductController(StoreContext context){
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> GetProducts([FromBody]Product product)
        {
           await _context.Products.AddAsync(product);
           await _context.SaveChangesAsync();
           return await _context.Products.FirstOrDefaultAsync();
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute]int Id)
        {
            return await _context.Products.FirstOrDefaultAsync(e => e.Id == Id);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProductById([FromRoute] int Id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(e => e.Id == Id);

            if (product is not null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return Ok("deleted!");
            }
            else
                return BadRequest($"product_dosn't_ exist!");
        }
    }
}
