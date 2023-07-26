namespace School.Core.Repositories;

public class ClassRoomRepository : GenericRepository<ClassRoom>
{
    public ClassRoomRepository(ILogger<GenericRepository<ClassRoom>> logger, SchoolDbContext context) : base(logger, context)
    {
    }
}

