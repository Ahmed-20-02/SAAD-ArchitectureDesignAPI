namespace SoftwareArchitectureDesignAPI.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("role_permission")]
    public class RolePermission
    {
        [Key]
        [Column("RolePermissionId")]
        public int RolePermissionId { get; set; }
        
        [Column("Name")]
        public string Name { get; set; }
        
        [Column("IsEnabled")]
        public bool IsEnabled { get; set; }
        
        [Column("RoleId"), ForeignKey("RoleId")]
        public Role Role { get; set; }   
        
        [Column("PermissionId"), ForeignKey("PermissionId")]
        public Permission Permission { get; set; }  
    }
}