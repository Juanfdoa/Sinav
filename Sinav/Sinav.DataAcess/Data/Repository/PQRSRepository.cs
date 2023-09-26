using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository
{
    public class PQRSRepository: Repository<PQRS>, IPQRSRepository
    {
        private readonly ApplicationDbContext _context;

        public PQRSRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public void MarkAsRead(int id)
        {

            var pqrsDb = _context.TblPQRS.FirstOrDefault(p => p.Id == id);
            if (pqrsDb != null)
            {
                pqrsDb.IsRead = true;
            }
        }

        public void Update(PQRS pqrs)
        {
            var pqrsDb = _context.TblPQRS.FirstOrDefault(p => p.Id == pqrs.Id);
            if (pqrsDb != null)
            {
                pqrsDb.Name = pqrs.Name;
                pqrsDb.Email = pqrs.Email;
                pqrsDb.Message = pqrs.Message;
                pqrsDb.IsRead = pqrs.IsRead;
                pqrsDb.UpdatedAt = DateTime.Now;
            }
        }
    }
}
