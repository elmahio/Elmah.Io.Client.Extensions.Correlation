using Elmah.Io.Client.Extensions.Correlation.AspNetCore.Net10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Elmah.Io.Client.Extensions.Correlation.AspNetCore.Net10.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        public IActionResult Index()
        {
            logger.LogWarning("An error is about to happen");
            throw new InvalidOperationException("The error happens");
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
