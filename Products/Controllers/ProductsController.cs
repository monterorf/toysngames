using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Data;
using Products.Models;

namespace Products.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            private readonly IProductRepository _repo;
            public ProductsController(IProductRepository repo)
            {
                _repo = repo;
            }


            [HttpPost]
            public async Task<IActionResult> CreateProduct(Product product)
            {
                _repo.CreateProduct(product);
                if (await _repo.SaveAll())
                {
                    return Ok();
                }

                throw new Exception("Creating the new product failed on save");
            }

            [HttpGet]
            public async Task<IActionResult> GetProducts()
            {
                var products = await _repo.GetProducts();

                return Ok(products);
            }


            [HttpGet("{id}")]
            public async Task<IActionResult> GetProduct(int id)
            {
                var product = await _repo.GetProduct(id);

                return Ok(product);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> EditProduct(int id, Product product)
            {
                var productEdited = await _repo.EditProduct(id, product);

                return Ok(productEdited);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProduct(int id)
            {
                var productFromRepo = await _repo.GetProduct(id);

                if (productFromRepo != null)
                    _repo.DeleteProduct(id);

                if (await _repo.SaveAll())
                    return Ok();

                return BadRequest("Failed to delete the photo");

            }


        }
    
}
