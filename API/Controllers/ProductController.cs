using API.DTOS;
using API.Helper;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController(
        IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductType> productTypesRepo,
        IGenericRepository<ProductBrand> productsBrandRepo,
        IMapper mapper,
        IConfiguration config)
        : BaseApiController
    {
        private IConfiguration Config { get; } = config;

        #region Product

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<PaginationHelper<ProductDTO>>> GetProductsAsync([FromQuery] ProductSpecsParams _params){
            var spec  = new ProductsWithTypesAndBrandSpecifications(_params);
            var countSpec = new ProductWithCountAndFilterSpecification(_params);
            var totalItems = await productsRepo.CountProductAsync(countSpec);
            var products = await  productsRepo.ListAsync(spec);
            var data = products.Select(product => new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureURL = this.Config["ApiURL"] + product.PictureURL,
                Price = product.Price,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            }).ToList();
            //var data = _mapper.Map<IList<Product>, IList<ProductDTO>>(products);
            return Ok(new PaginationHelper<ProductDTO>(_params.PageIndex,_params.PageSize,totalItems,data));
        }
        [HttpGet]
        [Route("GetProduct")]
        public async Task<ActionResult> GetProduct(int id){
            var spec  = new ProductsWithTypesAndBrandSpecifications(id);
            var product =  await productsRepo.GetEntityWithSpec(spec);
            var data = mapper.Map<Product, ProductDTO>(product);
            return Ok(data);
        }   
        [HttpGet]
        [Route("GetProductTypes")]
        public async Task<IActionResult> GetProductTypes(){
            var productTypes =  await productTypesRepo.ListAllAsync();
            return Ok(productTypes);
        }
        [HttpGet]
        [Route("GetProductBrands")]
        public async Task<IActionResult> GetProductBrands(){
            var productBrands =  await productsBrandRepo.ListAllAsync();
            return Ok(productBrands);
        }  

        #endregion
    }
}