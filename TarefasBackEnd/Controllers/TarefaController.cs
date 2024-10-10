using System;
using Microsoft.AspNetCore.Mvc;
using TarefasBackEnd.Models;
using TarefasBackEnd.Repositories;

namespace TarefasBackEnd.Controllers
{
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices]ITarefaRepository repository) 
        {
            var tarefas = repository.Read();
            return Ok(tarefas);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Tarefa model, [FromServices]ITarefaRepository repository)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            repository.Create(model);
            return Ok();
        }
    }
}