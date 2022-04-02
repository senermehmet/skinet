using Core.Entities;

namespace Core.Spesifications
{
        public class ProductsWithTypesAndBrandsSpesification : BaseSpesification<Product>
    {

        /// <summary>
        /// Class <c>ProductsWithTypesAndBrandsSpesification</c> Get All Products With Types and Brands
        /// </summary>
        ///<returns><c>List</c> of Core.Entities.Product</returns>
        public ProductsWithTypesAndBrandsSpesification()
        {
            AddInclude(t => t.ProductType);
            AddInclude(b => b.ProductBrand);
        }

        /// <summary>
        /// Class <c>ProductsWithTypesAndBrandsSpesification</c> Get Product With Type and Brand
        /// </summary>
        /// <param name="id">The Product Id.</param>
        /// <returns><c>Class</c> Core.Entities.Product</returns>
        public ProductsWithTypesAndBrandsSpesification(int id) : base(x=> x.Id==id)
        {
             AddInclude(t => t.ProductType);
            AddInclude(b => b.ProductBrand);
        }
    }
}