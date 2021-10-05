using Jokenpo.Dto;
using Jokenpo.Enuns;
using Jokenpo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Jokenpo.Controllers
{
    [ApiController]
    [Route("Jokenpo/Move")]
    public class MoveController : ControllerBase
    {
        private readonly IMoveService _service;

        public MoveController(IMoveService service)
        {
            _service = service;
        }

        [HttpPost]
        public Guid AddMOve([FromBody] MoveDto move)
        {
            move.PlayPay = (GameParts)move.PlayPay;
            return _service.AddMove(move);
        }
        [HttpGet("{id}")]
        public MoveDto GetMove([FromRoute] Guid id)
        {
            return _service.GetMoveById(id);
        }

        [HttpDelete("{id}")]
        public string DeletarMove([FromRoute] Guid id)
        {
            return _service.DeleteMove(id);
        }
        [HttpGet]
        public List<MoveDto> GetListMoveDto()
        {
            return _service.GetListMoveAll();
        }


    }
}
