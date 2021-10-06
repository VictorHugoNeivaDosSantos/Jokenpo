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
                .ForMember(player => player.Email, dto => dto.MapFrom(src => src.Email))
                .ReverseMap();

            CreateMap<MoveDto, Move>()
                .ForMember(move => move.JogadorId, map => map.MapFrom(src => src.JogadorId))
                .ForMember(move => move.PlayPay, map => map.MapFrom(src => src.PlayPay))
                .ReverseMap();

            CreateMap<MatchDto, Match>()
                .ForMember(dest => dest.Moves, map => map.MapFrom(src => src.Moves))
                .ReverseMap();

            CreateMap<Match, MatchTwoDto>()
              .ForMember(dest => dest.Moves, map => map.MapFrom(src => src.Moves))
              .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id));
        }
    }
}
