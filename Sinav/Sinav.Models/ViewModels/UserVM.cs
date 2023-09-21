using Sinav.Models.Entities;

namespace Sinav.Models.ViewModels
{
    public class UserVM
    {
        public User User { get; set; }
        public IEnumerable<AllergyUser> GetListAllergyUser {  get; set; }
        public IEnumerable<DiseaseUser> GetListDiseaseUser { get; set; }
        public IEnumerable<VaccineUser> GetListVaccineUser { get; set; }
    }
}
