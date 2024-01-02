namespace SoftwareArchitectureDesignAPI.Data
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
          ChangeTracker.LazyLoadingEnabled = false;
        }
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<Visa> Visas { get; set; }
        
        public DbSet<Role> Roles { get; set; }
        
        public DbSet<Permission> Permissions { get; set; }
        
        public DbSet<RolePermission> RolePermissions { get; set; }
        
        public DbSet<Document> Documents { get; set; }
        
        public DbSet<VisaDocument> VisaDocuments { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Application> Applications { get; set; }
        
        public DbSet<ApplicationDocument> ApplicationsDocuments { get; set; }
    }
}