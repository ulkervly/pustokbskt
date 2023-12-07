using PustokPractice.DAL;
using PustokPractice.Models;
using Pustok.Repositories.Interfaces;

namespace Pustok.Data.Repositories.Implementations
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
