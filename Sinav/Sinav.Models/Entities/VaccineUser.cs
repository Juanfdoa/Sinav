using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sinav.Models.Entities
{
    public class VaccineUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VaccineId { get; set; }
        [ForeignKey("VaccineId")]
        public Vaccine Vaccine { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int Dose { get; set; }
        public string Rate { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
