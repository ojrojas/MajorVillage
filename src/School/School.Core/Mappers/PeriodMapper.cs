namespace School.Core.Mappers;

public class PeriodMapper: Profile
{
	public PeriodMapper()
	{
		CreateMap<Period, GrpcSchool.Period>()
			.ForMember(x => x.Id, map => map.MapFrom(x => x.Id))
            .ForMember(x => x.Name, map => map.MapFrom(x => x.Name))
            .ForMember(x => x.Startdate, map => map.MapFrom(x => x.StartDate))
            .ForMember(x => x.Enddate, map => map.MapFrom(x => x.EndDate))
            .ForMember(x => x.Periodstatus, map => map.MapFrom(x => x.PeriodStatus))
            .ReverseMap();
	}
}