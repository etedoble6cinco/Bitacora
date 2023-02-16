using BitacoraAPP.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitacoraAPP.Controllers
{
    public class BitacoraController : Controller
    {
        private readonly IBitacoraService _bitacoraService;

        public BitacoraController( IBitacoraService bitacoraService)
        {
            this._bitacoraService = bitacoraService;    
        }
        public async Task<IActionResult> Index()
        {

            var ListaUsuarios = await _bitacoraService.GetDashboardBitacoraService();
            return View(ListaUsuarios);
            
        }

        
    }
}
