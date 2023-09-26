using ETicaret.Models;
using ETicaret.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _ProductRepo;
        public ProductController(ProductRepository productRepo)
        {
            _ProductRepo = productRepo;
        }
        [HttpGet]
        public IActionResult GetProduct()
        {
            var AllProduct = _ProductRepo.List();
            if (AllProduct != null)
            {
                return Ok(AllProduct);
            }
            { return BadRequest("Ürün Bulunamadı"); }
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            var yeniUrun = new Product
            {
                Title = product.Title,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Quantity = product.Quantity,
                InStock = product.InStock,
                CategoryId = product.CategoryId,
                Img = product.Img

            };
            _ProductRepo.Add(yeniUrun);

            return Ok(yeniUrun);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var SecilenÜrün = _ProductRepo.Queryable().Where(x => x.Id == id).FirstOrDefault();
            if (SecilenÜrün != null)
            {
                _ProductRepo.Delete(SecilenÜrün);
                return Ok("Ürün kaldırıldı.");
            }
                return BadRequest("Ürün bulunamadı.");
        }

    }
}
