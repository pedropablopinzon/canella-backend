using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace backend_canella.Models
{
    [Table("brand", Schema = "dbo")]
    public class Brands
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int id { get; set; }

        [Required]
        [Display(Name = "name")]
        [NotNull]
        public string name { get; set; }

        public static implicit operator Brands(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
