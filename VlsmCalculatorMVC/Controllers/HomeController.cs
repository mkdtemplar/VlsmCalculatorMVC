using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VlsmCalculatorMVC.Models;
using VlsmDBContext;

namespace VlsmCalculatorMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VlsmDB db;

        public HomeController(ILogger<HomeController> logger, VlsmDB injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public async Task<IActionResult> ReadResult()
        {
            var model = new HomeIndexViewModel
            {
                vlsmresults = await db.Vlsmresults.ToListAsync()
            };
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Author()
        {
            return View();
        }
       [HttpPost]
        public IActionResult VlsmCalculate(VlsmCalculateModel vlsmCalculate)
        {
            int firstoctet = vlsmCalculate.firstOctet;
            int secondoctet = vlsmCalculate.secondOctet;
            int thirdoctet = vlsmCalculate.thirdOctet;
            int fourthoctet = vlsmCalculate.fourthOctet;
            int cidr = vlsmCalculate.cidrValue;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
