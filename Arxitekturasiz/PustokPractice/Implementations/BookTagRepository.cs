using PustokPractice.DAL;
using PustokPractice.Models;
using Pustok.Repositories.Interfaces;

namespace Pustok.Data.Repositories.Implementations
{
    public class BookTagRepository : GenericRepository<BookTag>, IBookTagsRepository
    {
        public BookTagRepository(AppDbContext context) : base(context)
        {
        }
    }
}
