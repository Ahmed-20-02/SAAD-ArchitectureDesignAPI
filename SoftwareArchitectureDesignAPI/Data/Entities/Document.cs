namespace SoftwareArchitectureDesignAPI.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("document")]
    public class Document
    {
        [Key]
        [Column("DocumentId")]
        public int DocumentId { get; set; }
        
        [Column("Name")]
        public string Name { get; set; }
    }
}