namespace SoftwareArchitectureDesignAPI.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("visa_document")]
    public class VisaDocument
    {
        [Key]
        [Column("VisaDocumentId")]
        public int VisaDocumentId { get; set; }
        
        [Column("Name")]
        public string Name { get; set; }
        
        [Column("VisaId"), ForeignKey("VisaId")]
        public Visa Visa { get; set; }   
        
        [Column("DocumentId"), ForeignKey("DocumentId")]
        public Document Document { get; set; }  
    }
}