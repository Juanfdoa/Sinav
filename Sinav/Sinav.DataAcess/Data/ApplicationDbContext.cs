using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sinav.Models.Entities;

namespace Sinav.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> TblUser { get; set; }
        public DbSet<Supplier> TblSupplier { get; set; }
        public DbSet<Vaccine> TblVaccine { get; set; }
        public DbSet<Allergy> TblAllergy { get; set; }
        public DbSet<Disease> TblDisease { get; set; }
        public DbSet<AllergyUser> TblAllergyUser { get; set; }
        public DbSet<DiseaseUser> TblDiseaseUser { get; set; }
        public DbSet<VaccineUser> TblVaccineUser { get; set; }
    }
}