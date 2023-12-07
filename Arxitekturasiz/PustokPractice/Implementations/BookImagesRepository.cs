using PustokPractice.DAL;

using Pustok.Repositories.Interfaces;
using PustokPractice.Models;

namespace Pustok.Data.Repositories.Implementations
{
    public class BookImagesRepository : GenericRepository<BookImage>, IBookImagesRepository
    {
        public BookImagesRepository(AppDbContext context) : base(context)
        {
        }
    }
}
