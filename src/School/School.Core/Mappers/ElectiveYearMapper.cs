namespace School.Core.Mappers;

public class ElectiveYearMapper : Profile
{
	public ElectiveYearMapper()
	{
		CreateMap<ElectiveYear, GrpcSchool.ElectiveYear>()
			.ForMember(x => x.Id, map => map.MapFrom(x => x.Id))
			.ForMember(x => x.Year, map => map.MapFrom(x => x.Year))
			.ReverseMap();
    }
}

