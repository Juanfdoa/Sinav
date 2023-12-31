﻿using System.ComponentModel.DataAnnotations;

namespace Sinav.Models.Entities
{
    public class Disease
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //public virtual ICollection<DiseaseUser> DiseaseUsers { get; set; }
    }
}
