using System.ComponentModel.DataAnnotations;

namespace ImportDbApi.Models
{
    public partial class Ward
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
        public string DistrictCode { get; set; }
    }
}