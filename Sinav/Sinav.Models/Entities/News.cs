using System.ComponentModel.DataAnnotations;

namespace Sinav.Models.Entities
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


    }
}
