using BitacoraAPP.Models;
using BitacoraAPP.Models.AssetConsultViewModels;

namespace BitacoraAPP.Services
{
    public interface IAssetQrCodeImageService
    {
        Task<AssetQrImage> InsertAssetQrCodeImageAsync();
        Task<AssetQrImageViewModel> GetAssetQrCodeImageAsync();
        Task<List<AssetConsultViewModel>> GetAssetQrCodeImageListAsync();
        Task<List<AssetConsultViewModel>> GetAssetNoQrCodeImageListAsync(); 
        

        
    }
}
