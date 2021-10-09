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

            if (_servicePlayer.GetPlayerById(move.JogadorId) != null)
            {

                if (CheckIfPlayerExistsAtGame(match, move.JogadorId) == false)
                {
                    move.MatchId = match.Id;
                    match.Moves.Add(move);

                    if (match.Moves.Count == 3)
                    {
                        match.Status = StatusMatch.Fechada;
                    }

                    return match.Id;
                }

                throw new Exception("Este jogador já jogou nesta partida");
            }

            throw new Exception("Jogador não encontrado");
        }

        public string AlterMoveInMatch(Guid idMatch, Guid moveId, MoveDto move)
        {
            var match = _repositoryMatch.GetMatchById(idMatch);
            if (match.Status == StatusMatch.Aberta)
            {
                var edition = match.Moves.Find(f => f.Id == moveId);
                edition.PlayPay = move.PlayPay;
            }
            else
            {
                throw new Exception("Partida já finalizada");
            }

            return "Jogada alterada";
        }
        public string DeletarJogadaInMatch(Guid matchId, Guid moveId)
        {
            var match = _repositoryMatch.GetMatchById(matchId) ?? throw new Exception("Partida não encontrada");
            match.Moves.Remove(match.Moves.Find(f => f.Id == moveId));

            return "Jogada excluída";
        }

        private bool CheckIfPlayerExistsAtGame(Match match, Guid jogadorId)
        {
            var result = match.Moves.Find(f => f.JogadorId == jogadorId);

            if (result == null)
            {
                return false;
            }

            return true;
        }

        public List<MatchTwoDto> GetListaMatch()
        {
            return _mapper.Map<List<MatchTwoDto>>(_repositoryMatch.ListMatch());
        }

        public PlayerDto GetWinnerInMatchById(Guid matchId)
        {
            var match = _repositoryMatch.GetMatchById(matchId);
            Guid whinner = ProcessingWinner(match.Moves);
            return _servicePlayer.GetPlayerById(whinner);
        }

        private Guid ProcessingWinner(List<Move> moves)
        {
            var choicePrimary = moves[0].PlayPay;
            switch (choicePrimary)
            {
                case GameParts.Pedra:
                    if (moves[1].PlayPay != GameParts.Papel && moves[2].PlayPay != GameParts.Papel)
                    {
                        return moves[0].JogadorId;
                    }
                    break;

                case GameParts.Papel:
                    if (moves[1].PlayPay != GameParts.Tesoura && moves[2].PlayPay != GameParts.Tesoura)
                    {
                        return moves[0].JogadorId;
                    }
                    break;

                case GameParts.Tesoura:
                    if (moves[1].PlayPay != GameParts.Pedra && moves[2].PlayPay != GameParts.Pedra)
                    {
                        return moves[0].JogadorId;
                    }
                    break;
            }

            throw new Exception("Ganhador não encontrado.");
        }
    }
}
