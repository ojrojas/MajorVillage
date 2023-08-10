namespace School.Core.Mappers;

public class AreaMapper : Profile
{
    public AreaMapper()
    {
        CreateMap<Area, GrpcSchool.Area>()
            .ForMember(x => x.Id, map => map.MapFrom(x => x.Id))
            .ForMember(x => x.Name, map => map.MapFrom(x => x.Name))
            .ForMember(x => x.State, map => map.MapFrom(x => x.State)).ReverseMap();
    }
}

