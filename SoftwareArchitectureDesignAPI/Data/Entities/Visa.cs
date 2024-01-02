namespace SoftwareArchitectureDesignAPI.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("visa")]
    public class Visa
    {
        [Key]
        [Column("VisaId")]
        public int VisaId { get; set; }
        
        [Column("Name")]
        public string Name { get; set; }
        
        [Column("IsEnabled")]
        public bool IsEnabled { get; set; }
        
        [Column("CountryId"), ForeignKey("CountryId")]
        public Country Country { get; set; }   
    }
}