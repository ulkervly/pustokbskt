using PustokPractice.DAL;
using PustokPractice.Models;
using Pustok.Repositories.Interfaces;

namespace Pustok.Data.Repositories.Implementations
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(AppDbContext context) : base(context)
        {
        }
    }
}
