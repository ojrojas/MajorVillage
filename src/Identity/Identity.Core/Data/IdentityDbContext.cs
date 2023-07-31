namespace Identity.Core.Data;

/// <summary>
/// Identity Db Context 
/// </summary>
public class IdentityAppDbContext: IdentityDbContext<ApplicationUser>
{
    /// <summary>
    /// Identity Constructor 
    /// </summary>
    /// <param name="options">Options builder</param>
    public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options): base(options) { }

    /// <summary>
    /// Type Identification
    /// </summary>
    public DbSet<TypeIdentification> TypeIdentifications { get; set; }
    /// <summary>
    /// Attendants
    /// </summary>
    public DbSet<Attendant> Attendants { get; set; }
    /// <summary>
    /// Type Users
    /// </summary>
    public DbSet<TypeUser> TypeUsers { get; set; }

    /// <summary>
    /// On model creating database, and specific change model
    /// </summary>
    /// <param name="modelBuilder">Model builder application</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>().HasIndex(u => new { u.TypeIdentificationId, u.Identification }).IsUnique();
        modelBuilder.Entity<Attendant>().HasIndex(a => new { a.TypeIdentificationId, a.Identification })
            .IsUnique();

        modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
    }
}