using BitacoraAPP.Models;
using BitacoraAPP.Models.AssetConsultViewModels;

namespace BitacoraAPP.Services
{
    public class AssetQrCodeImageService : IAssetQrCodeImageService
    {
        private readonly string connectionString = "Server=SMI-SS-WEBSERV1;Database=AMSDev;User ID=serversmi;Password=adminserver123!;MultipleActiveResultSets=true;Persist Security Info=False";

        public async Task<List<AssetConsultViewModel>> GetAssetNoQrCodeImageListAsync()
        {
            var procedure = "[GetAssetNoQrCodeImage]";

                        
        }

        public Task<AssetQrImageViewModel> GetAssetQrCodeImageAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<AssetConsultViewModel>> GetAssetQrCodeImageListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AssetQrImage> InsertAssetQrCodeImageAsync()
        {
            throw new NotImplementedException();
        }
    }
}
