using Microsoft.AspNetCore.Mvc;
using Practice_Assignment1.Models;
using Practice_Assignment1.Services;
using System.Diagnostics;

namespace Practice_Assignment1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQuoteService _quoteService;

       /* public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        public HomeController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }
        public IActionResult Index()
        {
            var quote = _quoteService.GetRandomQuote();
            return View(quote);
        }
        public IActionResult OtherPage()
        {
            var quote = _quoteService.GetRandomQuote();
            ViewBag.Count = (int)(TempData["PageCount"] ?? 0) + 1;
            TempData["PageCount"] = ViewBag.Count;
            return View(quote);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
