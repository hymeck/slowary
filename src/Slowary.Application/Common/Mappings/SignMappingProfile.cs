using AutoMapper;
using Slowary.Application.Commands.Signs;
using Slowary.Application.Responses.Signs;
using Slowary.Domain.Entities;

namespace Slowary.Application.Common.Mappings
{
    public class SignMappingProfile : Profile
    {
        public SignMappingProfile()
        {
            CreateMap<Sign, SignResponse>()
                .ForMember(d => d.SignId, map => map.MapFrom(s => s.Id))
                .ForMember(d => d.Example, map => map.MapFrom(s => s.Example ?? ""))
                .ForMember(d => d.Note, map => map.MapFrom(s => s.Note ?? ""))
                .ForMember(d => d.Semantics, map => map.MapFrom(s => s.Semantics ?? ""))
                .ForMember(d => d.Source, map => map.MapFrom(s => s.Source ?? ""));

            CreateMap<SignCreateCommand, Sign>();
            
            CreateMap<SignUpdateCommand, Sign>()
                .ForMember(d => d.Id, map => map.MapFrom(s => s.SignId));
            
            CreateMap<SignDeleteCommand, Sign>()
                .ForMember(d => d.Id, map => map.MapFrom(s => s.SignId));
        }
    }
}