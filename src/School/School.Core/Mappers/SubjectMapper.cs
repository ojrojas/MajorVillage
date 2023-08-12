namespace School.Core.Mappers;

public class SubjectMapper: Profile
{
	public SubjectMapper()
	{
		CreateMap<Subject, GrpcSchool.Subject>()
			.ForMember(x=> x.Id, map => map.MapFrom(x=> x.Id))
            .ForMember(x => x.Name, map => map.MapFrom(x => x.Name))
            .ForMember(x => x.Areaid, map => map.MapFrom(x => x.AreaId))
            .ForMember(x => x.Area, map => map.MapFrom(x => x.Area))
            .ReverseMap();
	}
}