using Microsoft.AspNetCore.Mvc.Rendering;
using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;


namespace Sinav.DataAcess.Data.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetListSuppliers()
        {
            return _context.TblSupplier.Where(x => x.Active).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }

        public void Update(Supplier supplier)
        {
            var supplierDB = _context.TblSupplier.FirstOrDefault(x => x.Id == supplier.Id);
            if (supplierDB != null)
            {
                supplierDB.Name = supplier.Name;
                supplierDB.Nit = supplier.Nit;
                supplierDB.Phone = supplier.Phone;
                supplierDB.Address = supplier.Address;
                supplierDB.Email = supplier.Email;
                supplierDB.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
