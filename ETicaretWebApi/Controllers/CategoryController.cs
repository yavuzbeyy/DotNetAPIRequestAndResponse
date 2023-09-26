using ETicaret.Models;
using ETicaret.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ETicaretWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _CategoryRepo;
        public CategoryController(CategoryRepository categoryRepo)
        {
            _CategoryRepo = categoryRepo;
        }
        [HttpGet]
        public IActionResult GetCategory()
        {
            var AllCategory = _CategoryRepo.List();
            if (AllCategory != null)
            {
                return Ok(AllCategory);
            }
            { return BadRequest("Kategori Bulunamadı"); }
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            var yeniUrun = new Category
            {
                Id = category.Id,
                Name = category.Name,

            };
            _CategoryRepo.Add(yeniUrun);

            return Ok(yeniUrun);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var SecilenKategori = _CategoryRepo.Queryable().Where(x => x.Id == id).FirstOrDefault();
            if (SecilenKategori != null)
            {
                _CategoryRepo.Delete(SecilenKategori);
                return Ok("Kategori kaldırıldı.");
            }
            
            {
                return BadRequest("Kategori bulunamadı.");
            }            
        }

      
    }
}
