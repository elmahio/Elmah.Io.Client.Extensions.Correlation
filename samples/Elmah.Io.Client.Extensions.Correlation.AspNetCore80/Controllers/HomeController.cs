using Elmah.Io.Client.Extensions.Correlation.AspNetCore80.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Elmah.Io.Client.Extensions.Correlation.AspNetCore80.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogWarning("An error is about to happen");
            throw new ApplicationException("The error happens");
            //return View();
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
