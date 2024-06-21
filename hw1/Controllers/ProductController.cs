using hw1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hw1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name ="p1", Description = "d1"},
            new Product { Id = 2, Name ="p2", Description="d2"},
            new Product { Id = 3, Name ="p3", Description = "d3"}
        };

        [HttpGet]
        public IActionResult Get( ) { return Ok(products); }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.First(product => product.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult NewProduct(Product request)
        {
            if (request is null)
            {
                return BadRequest();
            }
            var product = new Product
            {
                Id = request.Id ,
                Name = request.Name ,
                Description = request.Description ,
            };
            products.Add(product);
            return Ok(product);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id , Product request)
        {
            var currProduct = products.FirstOrDefault(product => product.Id == id);
            if (currProduct is null)
                return NotFound();

            currProduct.Name = request.Name;
            currProduct.Description = request.Description;
            return Ok(currProduct);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);
            if (product is null)
                return NotFound();
            products.Remove(product);
            return Ok();
        }
    }
}
