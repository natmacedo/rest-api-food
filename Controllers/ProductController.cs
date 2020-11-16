using OpenFoodApi.Models;
using OpenFoodApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace OpenFoodApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get() =>
            _productService.Get();

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public ActionResult<Product> Get(string id)
        {
            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            _productService.Create(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id.ToString() }, product);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] Product productIn)
        {
            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _productService.Update(id, productIn);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _productService.Remove(product.Id);

            return NoContent();
        }
    }
}
