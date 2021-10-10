using AutoMapper;
using Jokenpo.Dto;
using Jokenpo.Models;

namespace Jokenpo.Mapper
{
    public class MapperDto : Profile
    {
        public MapperDto()
        {
            CreateMap<PlayerDto, Player>()
                .ForMember(player => player.Name, dto => dto.MapFrom(src => src.Name))
                .ForMember(player => player.Id, dto => dto.MapFrom(src => src.PlayerId))
                .ForMember(player => player.Status, dto => dto.MapFrom(src => src.Status))
                .ReverseMap();

            CreateMap<MoveDto, Move>()
                .ForMember(move => move.JogadorId, map => map.MapFrom(src => src.JogadorId))
                .ForMember(move => move.PlayerMove, map => map.MapFrom(src => src.PlayPay))
                .ReverseMap();

            CreateMap<Match, MatchListDto>()
              .ForMember(dest => dest.Moves, map => map.MapFrom(src => src.Moves));
        }
    }
}
