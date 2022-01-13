using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}