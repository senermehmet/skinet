using System.Text.Json;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeedData
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {

            try
            {
                if (!context.ProductBrands.Any())
                {

                    using var transaction = context.Database.BeginTransaction();
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData); ;

                    foreach (var brand in brands)
                    {
                        context.ProductBrands.Add(brand);
                    }
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductBrands ON");
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductBrands OFF");
                    transaction.Commit();

                }

                if (!context.ProductTypes.Any())
                {
                    using var transaction = context.Database.BeginTransaction();
                    var typesdata = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);

                    foreach (var type in types)
                    {
                        context.ProductTypes.Add(type);
                    }
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductTypes ON");
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductTypes OFF");
                    transaction.Commit();
                }
                if (!context.Products.Any())
                {
                    using var transaction = context.Database.BeginTransaction();
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var product in products)
                    {
                        context.Products.Add(product);
                    }
                    await context.SaveChangesAsync();
                    transaction.Commit();
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