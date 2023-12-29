
namespace SoftwareArchitectureDesignAPI.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("country")]
    public class Country
    {
        [Key]
        [Column("CountryId")]
        public int CountryId { get; set; }
        
        [Column("Name")]
        public string Name { get; set; }
        
        [Column("Capital")]
        public string Capital { get; set; }
        
        [Column("ISOCode")]
        public int ISOCode { get; set; }
    }
}