using Sinav.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface IVaccineRepository : IRepository<Vaccine>
    {
        void Update(Vaccine vaccine);
        IEnumerable<SelectListItem> GetListVaccines();
    }
}
