using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface ISliderRepository: IRepository<Slider>
    {
        void Update(Slider slider);
    }
}
