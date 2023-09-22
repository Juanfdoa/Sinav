using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly ApplicationDbContext _context;

        public SliderRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public void Update(Slider slider)
        {
            var sliderDb = _context.TblSlider.FirstOrDefault(x => x.Id == slider.Id);
            if (sliderDb != null)
            {
                sliderDb.Name = slider.Name;
                sliderDb.ImageUrl = slider.ImageUrl;
                sliderDb.Status = slider.Status;
                sliderDb.UpdatedAt = slider.UpdatedAt;
            }
        }
    }
}
