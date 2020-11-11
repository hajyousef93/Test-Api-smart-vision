using Microsoft.AspNetCore.Mvc;

using SmartVision.Data.Repository.ProductRepo;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartVision.Model;
using SmartVision.ModelViews.products;

namespace SmartVision.Controllers
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

        /// <summary>
        /// Get All Product
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("GetAllProduct")]
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            var products = await _repo.GetProducts();
            if (products == null)
            {
                return null;
            }
            return products;
        }
        /// <summary>
        /// Get Product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProduct/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            
            var product = await _repo.GetProduct(id);
            if (product != null)
            {
                return product;
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("EditProduct")]
        public async Task<ActionResult<Product>> EditUser(EditProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var product = await _repo.EditProduct(model);
            if (product != null)
            {
                return product;
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddUser(AddProductModel model)
        {
            if (ModelState.IsValid)
            {
                var Product = await _repo.AddProduct(model);
                if (Product != null)
                {
                    return Ok();
                }

            }
            return BadRequest();
        }

        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            
            var result = await _repo.DeleteProduct(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
