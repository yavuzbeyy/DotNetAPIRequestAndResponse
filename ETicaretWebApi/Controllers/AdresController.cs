using ETicaret.Models;
using ETicaret.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresController : ControllerBase
    {
        private readonly AdresRepository _AdresRepo;
        public AdresController(AdresRepository adresRepo)
        {
            _AdresRepo = adresRepo;
        }

        [HttpGet]
        public IActionResult GetAdres()
        {
            var AllAdres = _AdresRepo.List();
            if (AllAdres != null)
            {
                return Ok(AllAdres);
            }

            return BadRequest("Adres Bulunamadı"); 
        }
        [HttpPost]
        public IActionResult Create(Adres adres)
        {
            var yeniUrun = new Adres
            {
                Id = adres.Id,
                Description = adres.Description,
                UserId = adres.UserId,

            };
            _AdresRepo.Add(yeniUrun);

            return Ok(yeniUrun);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var SecilenAdres = _AdresRepo.Queryable().Where(x => x.Id == id).FirstOrDefault();
            if (SecilenAdres != null)
            {
                _AdresRepo.Delete(SecilenAdres);
                return Ok("Adres kaldırıldı.");
            }
            
            {
                return BadRequest("Adres bulunamadı.");
            }
        }
    }
}