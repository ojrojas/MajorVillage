namespace Identity.Core.Specifications;

public class UserSpecifications:  Specification<User>
{
	public UserSpecifications()
	{
		Query
			.Include(x => x.TypeIdentification)
			.Include(x => x.TypeUser);
	}
}

