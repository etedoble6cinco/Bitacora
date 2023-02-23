

using BitacoraAPP.Models;
using BitacoraAPP.Models.AssetConsultViewModels;
using BitacoraAPP.Services;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace BitacoraAPP.Controllers
{
    [AllowAnonymous]
    public class AssetConsultController : Controller
    {
        private readonly IAssetConsultService _assetConsultService;
        public AssetConsultController(IAssetConsultService assetConsultService)
        {
            _assetConsultService = assetConsultService; 
        }



        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAssetConsult(int Id)
        {

            if (Id > 0)
            {
               
                return View(await _assetConsultService.GetAssetAllInfoByIdAsync(Id));
            }
            else
            {
                return NotFound();
            }

           

        }
       
    }
}
