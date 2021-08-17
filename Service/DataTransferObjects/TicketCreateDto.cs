using System.ComponentModel.DataAnnotations;

namespace Service.DataTransferObjects
{
    public partial class TicketCreateDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength()]
        public string Ticketnummer { get; set; }
    }
}
