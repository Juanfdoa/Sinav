using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface IVaccineRepository : IRepository<Vaccine>
    {
        void Update(Vaccine vaccine);
    }
}
