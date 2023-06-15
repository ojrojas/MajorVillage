namespace Identity.Core.Data;

public static class SeedIdentity
{
    public static UserApplication CreateUserApplicationRequest()
    {
        return new UserApplication()
        {
            Id = "886572d4-0f16-4411-a365-f5960465447f",
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
                Id = Guid.Parse("02277856-dcc6-44ac-895a-6733f13bbca3"),
                CreatedBy = Guid.Parse("886572d4-0f16-4411-a365-f5960465447f"),
                CreatedDate = DateTime.UtcNow,
                State = true,
                Name = "CC"
            },
            TypeIdentificationId = Guid.Parse("02277856-dcc6-44ac-895a-6733f13bbca3"),
            TypeUser = new()
            {
                Id = Guid.Parse("acae4028-e16b-4c61-a3d6-9b000851fee5"),
                CreatedBy = Guid.Parse("886572d4-0f16-4411-a365-f5960465447f"),
                CreatedDate = DateTime.UtcNow,
                State = true,
                Name = "Admin"
            },
            TypeUserId = Guid.Parse("acae4028-e16b-4c61-a3d6-9b000851fee5")
        };
    }
}

