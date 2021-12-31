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
        ICommandApiRepo commandApiRepo;
        public CommandsController(ICommandApiRepo commandApiRepo){
            this.commandApiRepo=commandApiRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            return Ok(commandApiRepo.GetAllCommands());
        }
    }
}