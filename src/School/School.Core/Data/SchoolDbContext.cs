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

    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<ElectiveYear> ElectiveYears { get; set; }

    /// <summary>
    /// On model creating database, and specific change model
    /// </summary>
    /// <param name="modelBuilder">Model builder application</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
    }
}
