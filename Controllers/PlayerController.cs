using Jokenpo.Dto;
using Jokenpo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Jokenpo.Controllers
{
    [ApiController]
    [Route("Jokenpo/Player")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _service;

        public PlayerController(IPlayerService service)
        {
            _service = service;
        }

        [HttpPost]
        public Guid AddPlayer([FromBody] PlayerDto player)
        {
            return _service.AddPlayer(player);
        }
        [HttpGet("{id}")]
        public PlayerDto GetPlayer([FromRoute] Guid id)
        {
            return _service.GetPlayerById(id);
        }

        [HttpDelete("{id}")]
        public string DeletarPlayer([FromRoute] Guid id)
        {
            return _service.DeletePlayer(id);
        }
        [HttpGet]
        public List<PlayerDto> GetPlayerDto()
        {
            return _service.GetPlayersAll();
        }


    }
}
