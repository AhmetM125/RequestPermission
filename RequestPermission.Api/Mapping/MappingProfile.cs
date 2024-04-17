using AutoMapper;
using RequestPermission.Api.Dtos.Employee;
using RequestPermission.Api.Entity;

namespace RequestPermission.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // i want to map from assembly


        CreateMap<EmployeeAddDto, EmployeeDto>().ReverseMap();

        CreateMap<EmployeeDto, Employee>().ReverseMap()
          .ForMember(source => source.Id, opt => opt.MapFrom(dest => dest.E_ID))
          .ForMember(source => source.Name, opt => opt.MapFrom(dest => dest.E_NAME))
          .ForMember(source => source.Surname, opt => opt.MapFrom(dest => dest.E_SURNAME))
          .ForMember(source => source.Department, opt => opt.MapFrom(dest => dest.E_DEPARTMENT))
          .ForMember(source => source.Title, opt => opt.MapFrom(dest => dest.E_TITLE));

        CreateMap<EmployeeDto,EmployeeUpdateDto>().ReverseMap();

    }
}
