using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandSpecifications : BaseSpecifications<Product>
    {
        public ProductsWithTypesAndBrandSpecifications(ProductSpecsParams _params) : base ( x => (!_params.BrandId.HasValue || x.ProductBrandId == _params.BrandId) && (!_params.TypeId.HasValue || x.ProductTypeId == _params.TypeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(o => o.Name);
            AddPagination(_params.PageSize*_params.PageIndex-1,_params.PageSize);
            if(!string.IsNullOrEmpty(_params.Sort)){
                switch(_params.Sort){
                    case  "priceAsc" :
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc" :
                        AddOrderByDesc(y => y.Price);
                        break;
                    default :
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }
        public ProductsWithTypesAndBrandSpecifications(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}