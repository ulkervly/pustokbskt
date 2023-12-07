using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pustok.Business.Services.Interfaces;
using Pustok.Core.Repositories.Interfaces;
using Pustok.MVC.ViewModels;

namespace Pustok.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBookRepository _bookRepository;

        public ProductController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult SetSession(string name)
        //{
        //    HttpContext.Session.SetString("UserName", name);

        //    return Content("Added to session");
        //}

        //public IActionResult GetSession()
        //{
        //    string username = HttpContext.Session.GetString("UserName");

        //    return Content(username);
        //}

        //public IActionResult RemoveSession()
        //{
        //    HttpContext.Session.Remove("UserName");

        //    return RedirectToAction("GetSession");
        //}

        //public IActionResult SetCookie(int id)
        //{
        //    List<int> ids = new List<int>();

        //    string idsStr = HttpContext.Request.Cookies["UserId"];

        //    if(idsStr is not null)
        //    {
        //        ids = JsonConvert.DeserializeObject<List<int>>(idsStr);
        //    }

        //    ids.Add(id);

        //    idsStr = JsonConvert.SerializeObject(ids);

        //    HttpContext.Response.Cookies.Append("UserId", idsStr);

        //    return Content("Added to cookie");
        //}

        //public IActionResult GetCookie()
        //{
        //    List<int> ids = new List<int>();

        //    string idsStr = HttpContext.Request.Cookies["UserId"];
        //    if(idsStr is not null)
        //        ids = JsonConvert.DeserializeObject<List<int>>(idsStr);


        //    return Json(ids);
        //}


        public IActionResult AddToBasket(int bookId)
        {

            if (!_bookRepository.Table.Any(x => x.Id == bookId)) return NotFound(); // 404

            List<BasketItemViewModel> basketItemList = new List<BasketItemViewModel>();
            BasketItemViewModel basketItem = null;
            string basketItemListStr = HttpContext.Request.Cookies["BasketItems"];

            if (basketItemListStr != null)
            {
                basketItemList = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basketItemListStr);

                basketItem = basketItemList.FirstOrDefault(x => x.BookId == bookId);

                if (basketItem != null)
                {
                    basketItem.Count++;
                }
                else
                {
                    basketItem = new BasketItemViewModel()
                    {
                        BookId = bookId,
                        Count = 1
                    };

                    basketItemList.Add(basketItem);
                }
            }
            else
            {
                basketItem = new BasketItemViewModel()
                {
                    BookId = bookId,
                    Count = 1
                };

                basketItemList.Add(basketItem);
            }

            basketItemListStr = JsonConvert.SerializeObject(basketItemList);

            HttpContext.Response.Cookies.Append("BasketItems", basketItemListStr);

            return Ok(); //200
        }

        public IActionResult GetBasketItems()
        {
            List<BasketItemViewModel> basketItemList = new List<BasketItemViewModel>();

            string basketItemListStr = HttpContext.Request.Cookies["BasketItems"];

            if (basketItemListStr != null)
            {
                basketItemList = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basketItemListStr);
            }

            return Json(basketItemList);
        }

        public async Task<IActionResult> Checkout()
        {
            List<CheckOutViewModel> checkoutItemList = new List<CheckOutViewModel>();
            List<BasketItemViewModel> basketItemList = new List<BasketItemViewModel>();
            CheckOutViewModel checkoutItem = null;

            string basketItemListStr = HttpContext.Request.Cookies["BasketItems"];
            if (basketItemListStr != null)
            {
                basketItemList = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basketItemListStr);

                foreach (var item in basketItemList)
                {
                    checkoutItem = new CheckOutViewModel
                    {
                        Book = await _bookRepository.GetByIdAsync(x => x.Id == item.BookId),
                        Count = item.Count
                    };
                    checkoutItemList.Add(checkoutItem);
                }
            }

            return View(checkoutItemList);
        }
    }
}
