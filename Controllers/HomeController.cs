using BitacoraAPP.Models;
using BitacoraAPP.Services;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace BitacoraAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBitacoraService _bitacoraService;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return NotFound();
            }

          
        }
    

    }
}