using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sinav.Models.Entities
{
    public class DiseaseUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DiseaseId { get; set; }
        [ForeignKey("DiseaseId")]
        public Disease Disease { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public string Observations { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
