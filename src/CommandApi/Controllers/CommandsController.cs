using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandApi.Data;
using CommandApi.Models;

namespace CommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        ICommandApiRepo _repository;
        public CommandsController(ICommandApiRepo commandApiRepo)
        {
            this._repository = commandApiRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            return Ok(_repository.GetAllCommands());
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return Ok(commandItem);
        }
    }
}