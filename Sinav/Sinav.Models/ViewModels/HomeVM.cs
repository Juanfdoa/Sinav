using Sinav.Models.Entities;

namespace Sinav.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> sliders { get; set; }
        public IEnumerable<News> News { get; set; }
    }
}
