using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace AupetsServer;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Usuario, UsuarioDto>();
        CreateMap<UsuarioForCreationDto, Usuario>();
        CreateMap<UsuarioForUpdateDto, Usuario>();

        CreateMap<Status, StatusDto>();
        CreateMap<StatusForCreationDto, Status>();
        CreateMap<StatusForUpdateDto, Status>();

        CreateMap<Especie, EspecieDto>();
        CreateMap<EspecieForCreationDto, Especie>();
        CreateMap<EspecieForUpdateDto, Especie>();

        CreateMap<Especializacao, EspecializacaoDto>();
        CreateMap<EspecializacaoForCreationDto, Especializacao>();
        CreateMap<EspecializacaoForUpdateDto, Especializacao>();

        CreateMap<Atuacao, AtuacaoDto>();
        CreateMap<AtuacaoForCreationDto, Atuacao>();
        CreateMap<AtuacaoForUpdateDto, Atuacao>();

        CreateMap<Prestador, PrestadorDto>().ReverseMap();
        CreateMap<PrestadorForCreationDto, Prestador>()
            .ForMember(dest => dest.Imagem, map => map.Ignore());
        CreateMap<PrestadorForUpdateDto, Prestador>()
            .ForMember(dest => dest.Imagem, map => map.Ignore());

        CreateMap<Avaliacoes, AvaliacaoDto>();
        CreateMap<AvaliacaoForCreationDto, Avaliacoes>();
        CreateMap<AvaliacaoForUpdateDto, Avaliacoes>();
        
    }        
}