namespace School.Core.Data;

/// <summary>
/// Identity Db Context 
/// </summary>
public class SchoolDbContext: DbContext
{
    /// <summary>
    /// Identity Constructor 
    /// </summary>
    /// <param name="options">Options builder</param>
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options): base(options) { }

    /// <summary>
    /// Table courses
    /// </summary>
    public DbSet<Course> Courses { get; set; }
    /// <summary>
    /// Table ClassRooms
    /// </summary>
    public DbSet<ClassRoom> ClassRooms { get; set; }
    /// <summary>
    /// Table Enrollments
    /// </summary>
    public DbSet<Enrollment> Enrollments { get; set; }
    /// <summary>
    /// Table ElectiveYears
    /// </summary>
    public DbSet<ElectiveYear> ElectiveYears { get; set; }
    /// <summary>
    /// Table Areas
    /// </summary>
    public DbSet<Area> Areas { get; set; }
    /// <summary>
    /// Table Periods
    /// </summary>
    public DbSet<Period> Periods { get; set; }
    /// <summary>
    /// Table subjects
    /// </summary>
    public DbSet<Subject> Subjects { get; set; }

    /// <summary>
    /// On model creating database, and specific change model
    /// </summary>
    /// <param name="modelBuilder">Model builder application</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
    }
}
