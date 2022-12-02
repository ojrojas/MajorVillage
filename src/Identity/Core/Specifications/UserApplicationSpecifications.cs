namespace Core.Specifications
{
    public class UserApplicationSpecifications : Specification<UserApplication>
    {
        public UserApplicationSpecifications(string userName, string password)
        {
            Query.Where(x => x.UserName.Contains(userName) && x.Password.Equals(password))
                .Include(x => x.User).ThenInclude(t => t.TypeUser)
                .Include(x => x.User).ThenInclude(t => t.TypeIdentification);
                
        }
    }
}

