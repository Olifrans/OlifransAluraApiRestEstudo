using System.ComponentModel.DataAnnotations;

namespace OlifransAluraApiRestEstudo.Models
{
    public class Base
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}