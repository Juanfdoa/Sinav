using Sinav.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sinav.Models.ViewModels
{
    public class UserVM
    {
        public User User { get; set; }
        public VaccineUser VaccineUser { get; set; }
        public AllergyUser AllergyUser { get; set; }
        public DiseaseUser DiseaseUser { get; set; }
        public IEnumerable<SelectListItem> GetListVaccines {  get; set; }
        public IEnumerable<SelectListItem> GetListAllergies { get; set; }
        public IEnumerable<SelectListItem> GetListDiseases { get; set; }
        public IEnumerable<AllergyUser> GetListAllergyUser {  get; set; }
        public IEnumerable<DiseaseUser> GetListDiseaseUser { get; set; }
        public IEnumerable<VaccineUser> GetListVaccineUser { get; set; }
    }
}
