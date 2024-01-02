namespace SoftwareArchitectureDesignAPI.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("application_document")]
    public class ApplicationDocument
    {
        [Key]
        [Column("ApplicationDocumentId")]
        public int ApplicationDocumentId { get; set; }
        
        [Column("FileName")]
        public string FileName { get; set; }
        
        [Column("FilePath")]
        public string FilePath { get; set; }
        
        [Column("UploadedDate")]
        public DateTime UploadedDate { get; set; }
        
        [Column("UpdatedDate")]
        public DateTime UpdatedDate { get; set; }
        
        [Column("VisaDocumentId"), ForeignKey("VisaDocumentId")]
        public VisaDocument VisaDocument { get; set; }   
        
        [Column("ApplicationId"), ForeignKey("ApplicationId")]
        public Application Application { get; set; }  
    }
}