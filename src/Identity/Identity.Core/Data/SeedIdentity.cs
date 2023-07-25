namespace Identity.Core.Data;

public static class SeedIdentity
{
    public static UserApplication CreateUserApplicationRequest()
    {
        var UserApplicationId = Guid.NewGuid().ToString();
        var TypeIdentificationId = Guid.NewGuid();
        var TypeUserId = Guid.NewGuid();

        return new UserApplication()
        {
            Id = UserApplicationId,
            UserName = "pepe@example.com",
            Name = "Pepe",
            LastName = "Perez",
            Identification = "12345679",
            PasswordHash = "Abc123456#",
            BirthDate = DateTime.UtcNow,
            Address = "CL 1 # 1",
            Contact = "123451234",
            TypeIdentification = new()
            {
                Id = TypeIdentificationId,
                CreatedBy = Guid.Parse(UserApplicationId),
                CreatedDate = DateTime.UtcNow,
                State = true,
                Name = "CC"
            },
            TypeIdentificationId = TypeIdentificationId,
            TypeUser = new()
            {
                Id = TypeUserId,
                CreatedBy = Guid.Parse(UserApplicationId),
                CreatedDate = DateTime.UtcNow,
                State = true,
                Name = "Admin"
            },
            TypeUserId = TypeUserId
        };
    }
}

