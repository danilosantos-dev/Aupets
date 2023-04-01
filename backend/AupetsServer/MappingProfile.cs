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
    }        
}