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

        /// <summary>
        /// Rota utilizada para adicionar um player.
        /// </summary>
        [HttpPost]
        public Guid AddPlayer([FromBody] PlayerDto player)
        {
            return _service.AddPlayer(player);
        }

        /// <summary>
        /// Rota utilizada para buscar um player atravéz do Id.
        /// </summary>
        [HttpGet("{id}")]
        public PlayerDto GetPlayer([FromRoute] Guid id)
        {
            return _service.GetPlayerByIdDto(id);
        }

        /// <summary>
        /// Rota utilizada para desativar um player.
        /// </summary>
        [HttpDelete("{id}")]
        public string DeletarPlayer([FromRoute] Guid id)
        {
            return _service.DeletePlayer(id);
        }

        /// <summary>
        /// Retorna uma lista de todos os playes cadastrado no projeto.
        /// </summary>
        [HttpGet]
        public List<PlayerDto> GetPlayerDto()
        {
            return _service.GetPlayersAll();
        }


    }
}
