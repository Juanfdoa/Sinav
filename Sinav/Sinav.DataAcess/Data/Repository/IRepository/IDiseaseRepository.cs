using Sinav.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface IDiseaseRepository : IRepository<Disease>
    {
        void Update(Disease disease);
        IEnumerable<SelectListItem> GetListDiseases();
    }
}
