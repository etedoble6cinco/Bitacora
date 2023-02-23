using BitacoraAPP.Models;
using BitacoraAPP.Models.AssetConsultViewModels;

namespace BitacoraAPP.Services
{
    public interface IAssetConsultService
    {
        Task<AssetConsultViewModel> GetAssetByIdAsync(int id);
        Task<AssetUserProfileViewModel> GetAssetUserProfileAsync(int id);
        Task<AssetCategoryDepartment> GetAssetCategoryDepartmentAsync(int id);
        Task<AssetAllinfoViewModel> GetAssetAllInfoByIdAsync(int Id);
    }
}
