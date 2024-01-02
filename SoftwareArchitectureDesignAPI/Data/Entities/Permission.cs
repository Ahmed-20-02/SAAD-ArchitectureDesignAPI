namespace SoftwareArchitectureDesignAPI.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("permission")]
    public class Permission
    {
        [Key]
        [Column("PermissionId")]
        public int PermissionId { get; set; }
        
        [Column("Name")]
        public string Name { get; set; }
    }
}