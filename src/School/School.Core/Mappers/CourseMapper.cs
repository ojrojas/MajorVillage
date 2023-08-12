namespace School.Core.Mappers;

public class CourseMapper : Profile
{
	public CourseMapper()
	{
		CreateMap<Course, GrpcSchool.Course>()
			.ForMember(x => x.Id, map => map.MapFrom(x => x.Id))
            .ForMember(x => x.Name, map => map.MapFrom(x => x.Name))
            .ForMember(x => x.Coursedirectorid, map => map.MapFrom(x => x.CourseDirectorId))
            .ForMember(x => x.Currentperiodid, map => map.MapFrom(x => x.CurrentPeriodId))
            .ForMember(x => x.Coursestatus, map => map.MapFrom(x => x.CourseStatus))
            .ForMember(x => x.Electiveyear, map => map.MapFrom(x => x.ElectiveYear))
            .ForMember(x => x.Electiveyearid, map => map.MapFrom(x => x.ElectiveYearId))
            .ForMember(x => x.Classroom, map => map.MapFrom(x => x.ClassRoom))
            .ForMember(x => x.Classroom, map => map.MapFrom(x => x.ClassRoom))
            .ForMember(x => x.Classroomid, map => map.MapFrom(x => x.ClassRoomId))
            .ForMember(x => x.Students, map => map.MapFrom(x => x.Students))
            .ReverseMap();
    }
}