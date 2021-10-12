using AutoMapper;
using Jokenpo.Dto;
using Jokenpo.Enuns;
using Jokenpo.Models;
using Jokenpo.Repositories.Interface;
using Jokenpo.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Jokenpo.Services
{
    public class MatchService : IMatchService
    {
        private readonly IRepositoryMatch _repositoryMatch;
        private readonly IMapper _mapper;
        private readonly IPlayerService _servicePlayer;

        public MatchService(IRepositoryMatch repositoryMatch, IMapper mapper, IPlayerService servicePlayer)
        {
            _repositoryMatch = repositoryMatch;
            _mapper = mapper;
            _servicePlayer = servicePlayer;
        }

        private Match CreateMatch()
        {
            Match match = new Match
            {
                Id = Guid.NewGuid(),
                Moves = new List<Move>(),
                Status = StatusMatch.Aberta
            };

            _repositoryMatch.AddMatch(match);
            return match;
        }

        public Guid AddMoveInMatch(MoveDto moveDto)
        {
            var match = _repositoryMatch.GetOpenMatch() ?? CreateMatch();
            var move = _mapper.Map<Move>(moveDto);
            var player = _servicePlayer.GetPlayerById(move.JogadorId);

            if (player == null)
                throw new Exception("Jogador não encontrado.");

            if (player.Status == StatusPlayer.Desativo)
                throw new Exception("Jogador desativado");

            if (CheckIfPlayerExistsAtGame(match, move.JogadorId))
                throw new Exception("Jogador já existe nesta partida.");

            move.MatchId = match.Id;
            match.Moves.Add(move);

            if (match.Moves.Count == 3)
                match.Status = StatusMatch.Fechada;

            return match.Id;
        }

        private bool CheckIfPlayerExistsAtGame(Match match, Guid jogadorId)
        {
            var result = match.Moves.Find(f => f.JogadorId == jogadorId);

            if (result == null)
                return false;

            return true;
        }

        public List<MatchListDto> GetListMatch()
        {
            return _mapper.Map<List<MatchListDto>>(_repositoryMatch.ListMatch());
        }

        public PlayerDto GetWinnerInMatchById(Guid matchId)
        {
            var match = _repositoryMatch.GetMatchById(matchId) ??
                throw new Exception("Partida não encontrada");

            Guid whinner = ProcessingWinner(match.Moves);
            return _mapper.Map<PlayerDto>(_servicePlayer.GetPlayerById(whinner));
        }

        private Guid ProcessingWinner(List<Move> moves)
        {
            var choicePrimary = moves[0].PlayerMove;
            switch (choicePrimary)
            {
                case GameParts.Pedra:
                    if (moves[1].PlayerMove != GameParts.Papel && moves[2].PlayerMove != GameParts.Papel)
                        return moves[0].JogadorId;
                    break;

                case GameParts.Papel:
                    if (moves[1].PlayerMove != GameParts.Tesoura && moves[2].PlayerMove != GameParts.Tesoura)
                        return moves[0].JogadorId;
                    break;

                case GameParts.Tesoura:
                    if (moves[1].PlayerMove != GameParts.Pedra && moves[2].PlayerMove != GameParts.Pedra)
                        return moves[0].JogadorId;
                    break;
            }

            throw new Exception("Empate.");
        }
    }
}
