using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.ViewModels;
using PustokPractice.DAL;
using PustokPractice.Models;
using PustokPractice.ViewModels;

namespace PustokPractice.Controllers
{
    public class HomeController:Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel homeVm = new HomeViewModel()
            {
                Sliders=_context.Sliders.ToList(),
                FeaturedBooks=_context.Books.Include(x=>x.Author).Include(x=>x.BookImages).Where(x=>x.IsFeatured==true).ToList(),
                NewBooks=_context.Books.Include(x => x.Author).Include(x => x.BookImages).Where(x=>x.IsNew==true).ToList(),
                BestsellerBooks=_context.Books.Include(x => x.Author).Include(x => x.BookImages).Where(x=>x.IsBestseller==true).ToList(),
            };

            return View(homeVm);
        }
    }
}
