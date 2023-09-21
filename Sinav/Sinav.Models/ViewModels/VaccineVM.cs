using Microsoft.AspNetCore.Mvc.Rendering;
using Sinav.Models.Entities;

namespace Sinav.Models.ViewModels
{
    public class VaccineVM
    {
        public Vaccine Vaccine { get; set; }
        public IEnumerable<SelectListItem> SupplierList { get; set; }
    }
}
