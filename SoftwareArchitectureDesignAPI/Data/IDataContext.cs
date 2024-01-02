namespace SoftwareArchitectureDesignAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using SoftwareArchitectureDesignAPI.Data.Entities;
    
    public interface IDataContext
    {
        DbSet<Country> Countries { get; set; }
        DbSet<Visa> Visas { get; set; }
        
        DbSet<Role> Roles { get; set; }
        
        DbSet<Permission> Permissions { get; set; }
        
        DbSet<RolePermission> RolePermissions { get; set; }
        
        DbSet<Document> Documents { get; set; }
        
        DbSet<VisaDocument> VisaDocuments { get; set; }
        
        DbSet<User> Users { get; set; }
        
        DbSet<Application> Applications { get; set; }
        
        DbSet<ApplicationDocument> ApplicationsDocuments { get; set; }
    }
}