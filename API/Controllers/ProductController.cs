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
        #region Product

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProductsAsync(){
            var products = await  _repo.GetProductsAsync();
            return Ok(products);
        }
        [HttpGet]
        [Route("GetProduct")]
        public async Task<ActionResult> GetProduct(int id){
            var product =  await _repo.GetProductByIdAsync(id);
            return Ok(product);
        }   
        [HttpGet]
        [Route("GetProductTypes")]
        public async Task<IActionResult> GetProductTypes(){
            var productTypes =  await _repo.GetProductTypesAsync();
            return Ok(productTypes);
        }
        [HttpGet]
        [Route("GetProductBrands")]
        public async Task<IActionResult> GetProductBrands(){
            var productBrands =  await _repo.GetProductBrandsAsync();
            return Ok(productBrands);
        }  

        #endregion
    }
}