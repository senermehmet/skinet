using Core.Entities;

namespace Core.Spesifications
{
    public class ProductsWithTypesAndBrandsSpesification : BaseSpesification<Product>
    {
        public ProductsWithTypesAndBrandsSpesification()
        {
            AddInclude(t => t.ProductType);
            AddInclude(b => b.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpesification(int id) : base(x=> x.Id==id)
        {
             AddInclude(t => t.ProductType);
            AddInclude(b => b.ProductBrand);
        }
    }
}