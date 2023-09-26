using ETicaret.Models;
using ETicaret.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleRepository _RoleRepo;
        public RoleController(RoleRepository roleRepo)
        {
            _RoleRepo = roleRepo;
        }
        [HttpGet]
        public IActionResult GetUser()
        {
            var AllRole = _RoleRepo.List();
            if (AllRole != null)
            {
                return Ok(AllRole);
            }
            { return BadRequest("Rol Bulunamadı"); }
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            var yeniUrun = new Role
            {
                Id = role.Id,
                Rol = role.Rol,

            };
            _RoleRepo.Add(yeniUrun);

            return Ok(yeniUrun);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var SecilenRol = _RoleRepo.Queryable().Where(x => x.Id == id).FirstOrDefault();
            if (SecilenRol != null)
            {
                _RoleRepo.Delete(SecilenRol);
                return Ok("Rol kaldırıldı.");
            }
            
            {
                return BadRequest("Rol bulunamadı.");
            }
        }
    }
}
