using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VlsmCalculatorMVC.Models;
using VlsmCalculatorMVC.Views.Home;
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
        public  IActionResult vlsmCalculate()
        {
            var VlsmModel = new VlsmCalculateModel
            {
                firstOctet = int.Parse(Request.Form["first"]),
                secondOctet = int.Parse(Request.Form["second"]),
                thirdOctet = int.Parse(Request.Form["third"]),
                fourthOctet = int.Parse(Request.Form["fourth"]),
                cidrValue = int.Parse(Request.Form["cid"])
            };
            return View(VlsmModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
