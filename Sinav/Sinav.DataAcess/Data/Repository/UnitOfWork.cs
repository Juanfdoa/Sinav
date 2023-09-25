using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;

namespace Sinav.DataAcess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Supplier = new SupplierRepository(_context);
            Vaccine = new VaccineRepository(_context);
            Allergy = new AllergyRepository(_context);
            Disease = new DiseaseRepository(_context);
            AllergyUser = new AllergyUserRepository(_context);
            DiseaseUser = new DiseaseUserRepository(_context);
            VaccineUser = new VaccineUserRepository(_context);
            Slider = new SliderRepository(_context);
            Account = new AccountRepository(_context);
        }

        public IUserRepository User {  get; set; }
        public ISupplierRepository Supplier { get; set; }
        public IVaccineRepository Vaccine { get; set; }
        public IAllergyRepository Allergy { get; set; }
        public IDiseaseRepository Disease { get; set; }
        public IAllergyUserRepository AllergyUser { get; set; }
        public IDiseaseUserRepository DiseaseUser { get; set; }
        public IVaccineUserRepository VaccineUser { get; set; }
        public ISliderRepository Slider { get; set; }
        public IAccountRepository Account { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
