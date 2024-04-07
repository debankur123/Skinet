using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProductsAsync(){
            var products = await  _repo.GetProductsAsync();
            return Ok(products);
        }
        [HttpGet]
        [Route("GetProduct")]
        public async Task<ActionResult<dynamic>> GetProduct(int id){
            var product =  await _repo.GetProductByIdAsync(id);
            return product;
        }
    }
}