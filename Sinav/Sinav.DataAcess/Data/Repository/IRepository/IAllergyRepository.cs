using Sinav.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface IAllergyRepository : IRepository<Allergy>
    {
        void Update(Allergy allergy);
        IEnumerable<SelectListItem> GetListAllergies();
    }
}
