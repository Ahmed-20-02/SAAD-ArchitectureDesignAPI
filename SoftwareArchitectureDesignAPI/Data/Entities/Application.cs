namespace SoftwareArchitectureDesignAPI.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("application")]
    public class Application
    {
        [Key]
        [Column("ApplicationId")]
        public int ApplicationId { get; set; }
        
        [Column("Status")]
        public string Status { get; set; }
        
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        
        [Column("UpdatedDate")]
        public DateTime UpdatedDate { get; set; }
        
        [Column("VisaId"), ForeignKey("VisaId")]
        public Visa Visa { get; set; }  
        public int VisaId { get; set; }
        
        [Column("UserId"), ForeignKey("UserId")]
        public User User { get; set; } 
        public int UserId { get; set; }

    }
}