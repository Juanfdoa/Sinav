using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public void Update(User user)
        {
            var userDB = _context.TblUser.FirstOrDefault(x => x.Id == user.Id);
            if (userDB != null)
            {
                userDB.Name = user.Name;
                userDB.Surname = user.Surname;
                userDB.DocumentType = user.DocumentType;
                userDB.DocumentNumber = user.DocumentNumber;
                userDB.Gender = user.Gender;
                userDB.Address = user.Address;
                userDB.Phone = user.Phone;
                userDB.Birthdate = user.Birthdate;
                userDB.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
