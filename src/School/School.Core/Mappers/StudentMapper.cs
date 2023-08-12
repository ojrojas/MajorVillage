namespace School.Core.Mappers;

public class StudentMapper: Profile
{
	public StudentMapper()
	{
		CreateMap<Student, GrpcSchool.Student>()
			.ForMember(x=> x.Id, map => map.MapFrom(x=> x.Id))
			.ForMember(x=> x.Name, map => map.MapFrom(x=> x.Name))
            .ForMember(x => x.Lastname, map => map.MapFrom(x => x.LastName))
            .ReverseMap();
	}
}

