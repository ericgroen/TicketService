using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public partial class Ticket
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength()]
        public string Ticketnummer { get; set; }
    }
}
