using Sinav.Data;
using Sinav.DataAcess.Data.Repository.IRepository;
using Sinav.Models.Entities;

namespace Sinav.DataAcess.Data.Repository
{
    public class NewRepository: Repository<News>, INewRepository
    {
        private readonly ApplicationDbContext _context;

        public NewRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(News news)
        {
            var newDb = _context.TblNews.FirstOrDefault(x => x.Id == news.Id);
            if (newDb != null)
            {
                newDb.Name = news.Name;
                newDb.ImageUrl = news.ImageUrl;
                newDb.Description = news.Description;
                newDb.Status = news.Status;
                newDb.UpdatedAt = DateTime.Now;
            }
        }
    }
}
