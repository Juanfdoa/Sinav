using System.ComponentModel.DataAnnotations;

namespace Sinav.Models.Entities
{
    public class PQRS
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Category { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
