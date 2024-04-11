using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _prodRepo;
        private readonly IGenericRepository<ProductBrand> _prodBrandRepo;
        private readonly IGenericRepository<ProductType> _prodTypeRepo;
        public ProductController(IGenericRepository<Product> productsRepo,IGenericRepository<ProductType> productTypesRepo,IGenericRepository<ProductBrand> productsBrandRepo)
        {
            _prodRepo = productsRepo;
            _prodTypeRepo = productTypesRepo;
            _prodBrandRepo = productsBrandRepo;
        }
        #region Product

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProductsAsync(){
            var spec  = new ProductsWithTypesAndBrandSpecifications();
            var products = await  _prodRepo.ListAsync(spec);
            return Ok(products);
        }
        [HttpGet]
        [Route("GetProduct")]
        public async Task<ActionResult> GetProduct(int id){
            var spec  = new ProductsWithTypesAndBrandSpecifications(id);
            var product =  await _prodRepo.GetEntityWithSpec(spec);
            return Ok(product);
        }   
        [HttpGet]
        [Route("GetProductTypes")]
        public async Task<IActionResult> GetProductTypes(){
            var productTypes =  await _prodTypeRepo.ListAllAsync();
            return Ok(productTypes);
        }
        [HttpGet]
        [Route("GetProductBrands")]
        public async Task<IActionResult> GetProductBrands(){
            var productBrands =  await _prodBrandRepo.ListAllAsync();
            return Ok(productBrands);
        }  

        #endregion
    }
}