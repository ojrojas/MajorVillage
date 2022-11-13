﻿namespace Infraestructure.Data
{
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
        /// On model creating database, and specific change model
        /// </summary>
        /// <param name="modelBuilder">Model builder application</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
        }
    }
}
