using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TarefasBackEnd.Model;
using TarefasBackEnd.Model.ViewModels;
using TarefasBackEnd.Repositories;

namespace TarefasBackEnd.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody]Usuario model, [FromServices] IUsuarioRepository repository)
        {
            if(!ModelState.IsValid){
                return BadRequest();
            }

            repository.Create(model);

            return Ok();
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]UsuarioLogin model, [FromServices]IUsuarioRepository repository)
        {
            if(!ModelState.IsValid){
                return BadRequest();
            }

            Usuario usuario = repository.Read(model.Email, model.Senha);

            if (usuario == null){
                return Unauthorized();
            }
            usuario.Senha = "";

            return Ok(new {
                usuario = usuario
            });
        }
    }
}