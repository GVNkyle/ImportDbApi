using System.ComponentModel.DataAnnotations;

namespace crawler_api.Models
{
    public partial class District
    {
        [Key]
        [StringLength(5)]
        public string Code { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Level { get; set; }
        [Required]
        [StringLength(5)]
        public string ProvinceCode { get; set; }
    }
}