namespace Infraestructure.Data
{
    /// <summary>
    /// Identity Db Context 
    /// </summary>
    public class IdentityDbContext: DbContext
    {
        /// <summary>
        /// Identity Constructor 
        /// </summary>
        /// <param name="options">Options builder</param>
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options): base(options) { }

        /// <summary>
        /// Table Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Table TypeIdentifications
        /// </summary>
        public DbSet<TypeIdentification> TypeIdentifications { get; set; }

        /// <summary>
        /// Table attendants by students
        /// </summary>
        public DbSet<Attendant> Attendants { get; set; }

        /// <summary>
        /// Table User Application 
        /// </summary>
        public DbSet<UserApplication> UsersApplications { get; set; }

        /// <summary>
        /// On model creating database, and specific change model
        /// </summary>
        /// <param name="modelBuilder">Model builder application</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
        }
    }
}
