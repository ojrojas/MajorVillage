namespace School.Core.Mappers;

public class ClassRomMapper : Profile
{
	public ClassRomMapper()
	{
		CreateMap<ClassRoom, GrpcSchool.ClassRoom>()
			.ForMember(x => x.Id, map => map.MapFrom(x => x.Id))
			.ForMember(x => x.Name, map => map.MapFrom(x => x.Name))
			.ForMember(x => x.Classroomstatus, map => map.MapFrom(x => x.ClassRoomStatus))
			.ForMember(x => x.State, map => map.MapFrom(x => x.State)).ReverseMap();
	}
}