using System;
namespace Core.Repositories;

public class UserApplicationRepository : GenericRepository<UserApplication>
{
    public UserApplicationRepository(
        ILogger<GenericRepository<UserApplication>> logger,
        IdentityDbContext context) : base(logger, context)
    {

    }
}