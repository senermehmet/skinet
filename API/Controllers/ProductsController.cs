using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "Bu ürünleri dondüren bir liste olacak";
        }
        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "Bu tek bir ürün içerir ";
        }
    }
}