namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User {  get; }
        ISupplierRepository Supplier { get; }
        IVaccineRepository Vaccine { get; }
        IAllergyRepository Allergy { get; }
        IDiseaseRepository Disease { get; }
        IAllergyUserRepository AllergyUser { get; }
        IDiseaseUserRepository DiseaseUser { get; }
        IVaccineUserRepository VaccineUser { get; }
        ISliderRepository Slider { get; }
        IAccountRepository Account { get; }
        INewRepository News { get; }
        IPQRSRepository PQRS { get; }

        void Save();
    }
}
