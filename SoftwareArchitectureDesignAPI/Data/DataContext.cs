namespace SoftwareArchitectureDesignAPI.Data
{
    using Entities;
    
    using Microsoft.EntityFrameworkCore;
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        
        public DbSet<Country> Countries { get; set; }
    }
}