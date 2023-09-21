using System.ComponentModel.DataAnnotations;

namespace Sinav.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is requiered")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is requiered")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "This field is requiered")]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "This field is requiered")]
        public string DocumentNumber { get; set; }

        [Required(ErrorMessage = "This field is requiered")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "This field is requiered")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is requiered")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "This field is requiered")]
        public DateTime Birthdate { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public ICollection<AllergyUser> AllergyUsers { get; set; }
        public ICollection<DiseaseUser> DiseaseUsers { get; set; }


    }
}
