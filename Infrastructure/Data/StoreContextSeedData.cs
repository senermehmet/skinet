using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeedData
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {


                if (!context.Products.Any())
                {
                    if (!context.ProductTypes.Any())
                    {
                        var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                        var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                        foreach (var typeItem in types)
                        {
                            context.ProductTypes.Add(typeItem);
                        }

                        await context.SaveChangesAsync();
                    }
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach (var productItem in products)
                    {
                        context.Products.Add(productItem);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach (var brandItem in brands)
                    {
                        context.ProductBrands.Add(brandItem);
                    }
                    await context.SaveChangesAsync();
                }

            }
            catch (System.Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeedData>();
                logger.LogError(ex, "Oooops!.. Demo dataları eklendiği sırasında bir hata oluştu!");
            }
        }
    }
}