using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace backend_canella.Models
{
    [Table("agency", Schema = "dbo")]
    public class Agencies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int id { get; set; }

        [Required]
        [Display(Name = "name")]
        [NotNull]
        public string name { get; set; }

        [Required]
        [Display(Name = "address")]
        [NotNull]
        public string address { get; set; }

        [Required]
        [Display(Name = "phone")]
        [NotNull]
        public string phone { get; set; }

        [Required]
        [Display(Name = "webUrl")]
        [NotNull]
        public string webUrl { get; set; }

        public static implicit operator Agencies(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
