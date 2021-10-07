using Jokenpo.Dto;
using Jokenpo.Models;
using System;
using System.Collections.Generic;

namespace Jokenpo.Repositories.Interface
{
    public interface IRepositoryPlayer
    {
        Guid AddPlayer(Player player);
        void DeletarPlayer(Player id);
        Player GetPlayerById(Guid id);
        List<Player> GetPlayersAll();
    }
}