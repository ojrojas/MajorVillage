namespace Identity.Core.Specifications;

public class UserApplicationSpecifications : Specification<ApplicationUser>
{
    public UserApplicationSpecifications(string userName)
    {
        Query.Where(x => x.UserName!.Equals(userName))
            .Include(x=> x.TypeUser);
    }
}