using ETicaret.Models;
using ETicaret.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _UserRepo;
        public UserController(UserRepository userRepo)
        {
            _UserRepo = userRepo;
        }
        [HttpGet]
        public IActionResult GetUser()
        {
            var AllUser = _UserRepo.List();
            if (AllUser != null)
            {
                return Ok(AllUser);
            }
            { return BadRequest("Kullanıcı Bulunamadı"); }
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            var yeniUrun = new User
            {
                Id = user.Id,
                Name = user.Name,

            };
            _UserRepo.Add(yeniUrun);

            return Ok(yeniUrun);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var SecilenKullanici = _UserRepo.Queryable().Where(x => x.Id == id).FirstOrDefault();
            if (SecilenKullanici != null)
            {
                _UserRepo.Delete(SecilenKullanici);                
                return Ok("Kullanici kaldırıldı.");
            }
            
            {
                return BadRequest("Kullanici bulunamadı.");
            }


        }
    }
}
