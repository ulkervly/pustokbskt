using PustokPractice.DAL;

using Pustok.Repositories.Interfaces;
using PustokPractice.Models;

namespace Pustok.Data.Repositories.Implementations
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
