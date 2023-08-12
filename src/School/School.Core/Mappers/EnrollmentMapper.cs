namespace School.Core.Mappers;

public class EnrollmentMapper: Profile
{
	public EnrollmentMapper()
	{
		CreateMap<Enrollment, GrpcSchool.Enrollment>()
			.ForMember(x => x.Id, map => map.MapFrom(x => x.Id))
            .ForMember(x => x.Studentid, map => map.MapFrom(x => x.StudentId))
            .ForMember(x => x.Attendantid, map => map.MapFrom(x => x.AttendantId))
            .ForMember(x => x.Isapproved, map => map.MapFrom(x => x.IsApproved))
            .ForMember(x => x.Electiveyear, map => map.MapFrom(x => x.ElectiveYear))
            .ForMember(x => x.Electiveyearid, map => map.MapFrom(x => x.ElectiveYearId))
            .ForMember(x => x.Enrollmentstatus, map => map.MapFrom(x => x.EnrollmentStatus))
            .ReverseMap();
	}
}