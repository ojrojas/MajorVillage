namespace Identity.Core.Specifications;

public class UserApplicationSpecifications : Specification<UserApplication>
{
    public UserApplicationSpecifications(string userName)
    {
        Query.Where(x => x.UserName!.Equals(userName));
    }
}