using Microsoft.AspNetCore.Mvc.Rendering;
using Sinav.Models.Entities;


namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        void Update(Supplier supplier);
        IEnumerable<SelectListItem> GetListSuppliers();
    }
}
