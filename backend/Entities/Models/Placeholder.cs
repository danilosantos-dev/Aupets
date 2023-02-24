using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("placeholder")]
    public class Placeholder
    {
        [Key]
        public Guid PlaceholderId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}