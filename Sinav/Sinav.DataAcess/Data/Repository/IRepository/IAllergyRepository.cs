using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface IAllergyRepository : IRepository<Allergy>
    {
        void Update(Allergy allergy);
    }
}
