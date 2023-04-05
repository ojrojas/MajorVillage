namespace Identity.Core.Data;

public static class SeedIdentity
{
    public static UserApplication CreateUserApplicationRequest()
    {
        return new UserApplication()
        {
            Id = Guid.Parse("886572d4-0f16-4411-a365-f5960465447f"),
            CreatedBy = Guid.Parse("886572d4-0f16-4411-a365-f5960465447f"),
            CreatedDate = DateTime.UtcNow,
            State = true,
            UserName = "pepe@example.com",
            Password = "Pepe12345#",
            User = new()
            {
                Id = Guid.Parse("371c6236-270d-47bc-9d28-4851b4ad2181"),
                CreatedBy = Guid.Parse("886572d4-0f16-4411-a365-f5960465447f"),
                CreatedDate = DateTime.UtcNow,
                State = true,
                Name = "Pepe",
                LastName = "Perez",
                Identification = "12345679",
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
            },
            UserId = Guid.Parse("371c6236-270d-47bc-9d28-4851b4ad2181")
        };

    }

}

