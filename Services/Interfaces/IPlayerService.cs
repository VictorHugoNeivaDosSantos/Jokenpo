using Jokenpo.Dto;
using System;
using System.Collections.Generic;

namespace Jokenpo.Services.Interfaces
{
    public interface IPlayerService
    {
        Guid AddPlayer(PlayerDto playerDto);
        PlayerDto GetPlayerById(Guid id);
        string DeletePlayer(Guid id);
        List<PlayerDto> GetPlayersAll();
    }
}