using BitacoraAPP.Models;
using BitacoraAPP.Models.AssetConsultViewModels;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BitacoraAPP.Services
{
    public class AssetConsultService:IAssetConsultService
    {

        private readonly string connectionString = "Server=SMI-SS-WEBSERV1;Database=AMSDev;User ID=serversmi;Password=adminserver123!;MultipleActiveResultSets=true;Persist Security Info=False";
        private readonly ICommon _common;
        public AssetConsultService(ICommon common)
        {
            _common = common;   
        }
        public async Task<AssetConsultViewModel> GetAssetByIdAsync(int id)
        {
            AssetConsultViewModel asset = new AssetConsultViewModel();
            try
            {
             
                var procedure = "[GetAssetAllInfo]";
                using (var connection = new SqlConnection(connectionString))
                {
                    var assetConsulted = await connection.QuerySingleOrDefaultAsync<Asset>(procedure, new
                    {
                        IdAsset = id
                    }, commandType: CommandType.StoredProcedure);
                    if(assetConsulted != null)
                    {
                        asset.Id = assetConsulted.Id;
                        asset.Name = assetConsulted.Name;
                        asset.AssetId = assetConsulted.AssetId;
                        asset.AssetModelNo = assetConsulted.AssetModelNo;
                        asset.Description = assetConsulted.Description;
                        asset.Quantity = assetConsulted.Quantity;
                        asset.UnitPrice = assetConsulted.UnitPrice;
                        asset.Location = assetConsulted.Location;
                        asset.ImageURL = assetConsulted.ImageURL;
                        asset.PurchaseReceipt = assetConsulted.PurchaseReceipt;
                        asset.DateOfPurchase = assetConsulted.DateOfPurchase;
                        asset.DateOfManufacture = assetConsulted.DateOfManufacture;
                       
                        asset.YearOfValuation = assetConsulted.YearOfValuation;
                        asset.AssignEmployeeId = assetConsulted.AssetStatus;
                        asset.IsAvilable = assetConsulted.IsAvilable;
                        asset.Note = assetConsulted.Note;
                        asset.Barcode = assetConsulted.Barcode;
                        asset.QRCode = assetConsulted.QRCode;
                        asset.QRCodeImage = assetConsulted.QRCodeImage;
                        asset.SpecifySupplier = assetConsulted.SpecifySupplier;
                        Uri AssetImageUri = new Uri("http://192.168.10.4:5032" + assetConsulted.ImageURL);
                        asset.ImageString = await _common.GetImageHttpClientAsync(AssetImageUri);
                        asset.CreatedDate = assetConsulted.CreatedDate;
                        asset.ModifiedDate = assetConsulted.ModifiedDate;
                        asset.CreatedBy = assetConsulted.CreatedBy;
                        asset.ModifiedBy = assetConsulted.ModifiedBy;
                        asset.Cancelled = assetConsulted.Cancelled;
                        asset.AssetStatus = assetConsulted.AssetStatus;
                        if(assetConsulted.PurchaseReceipt != null)
                        {
                            asset.PurchaseReceipt = "http://192.168.10.4:5032"+assetConsulted.PurchaseReceipt;
                        }
                        

                    }

                   
                }
            
                return asset;
               
            }catch(SqlException e)
            {
                Console.WriteLine(e.ErrorCode.ToString());
                asset.Name = "Asset No Encontrado";
                return asset;
            }
        }
        public async Task<AssetUserProfileViewModel> GetAssetUserProfileAsync(int id)
        {
            AssetUserProfileViewModel assetUserProfileViewModel = new AssetUserProfileViewModel();  
            try
            {
                var procedure = "[GetAssetAssignedInfo]";
                using (var connection = new SqlConnection(connectionString))
                {
                    var UserProfileConsulted = await connection.QuerySingleOrDefaultAsync<AssetUserProfile>(procedure, new
                    {
                        IdAsset = id
                    }, commandType: CommandType.StoredProcedure);
                    if(UserProfileConsulted !=null) {
                        assetUserProfileViewModel.PhoneNumber = UserProfileConsulted.PhoneNumber;
                        assetUserProfileViewModel.FirstName = UserProfileConsulted.FirstName;
                        assetUserProfileViewModel.LastName = UserProfileConsulted.LastName;
                        assetUserProfileViewModel.Email = UserProfileConsulted.Email;
                        assetUserProfileViewModel.EmployeeCode = UserProfileConsulted.EmployeeCode;
                        assetUserProfileViewModel.UserName = UserProfileConsulted.UserName;
                        assetUserProfileViewModel.EmailConfirmed = UserProfileConsulted.EmailConfirmed;
                        assetUserProfileViewModel.AssignEmployeeId = UserProfileConsulted.AssignEmployeeId;
                        assetUserProfileViewModel.ProfilePicture = UserProfileConsulted.ProfilePicture;
                        assetUserProfileViewModel.CreatedDate = UserProfileConsulted.CreatedDate;
                        assetUserProfileViewModel.ModifiedDate = UserProfileConsulted.ModifiedDate;
                        assetUserProfileViewModel.CreatedBy = UserProfileConsulted.CreatedBy;
                        assetUserProfileViewModel.ModifiedBy = UserProfileConsulted.ModifiedBy;
                        assetUserProfileViewModel.Cancelled = UserProfileConsulted.Cancelled;

                    }
         


                    return assetUserProfileViewModel;
                }

            }catch(SqlException e)

            {
                Console.WriteLine(e.ErrorCode.ToString());
                assetUserProfileViewModel.FirstName = "Usuario no Encontrado";
                return assetUserProfileViewModel;
            }
        }
        public async Task<AssetCategoryDepartment> GetAssetCategoryDepartmentAsync(int id)
        {
            AssetCategoryDepartment assetCategoryDepartment = new AssetCategoryDepartment();
            try
            {
               
                var procedure = "[GetAssetCategoryDepartment]";
                using(var connection = new SqlConnection(connectionString))
                {
                    var CatergoryDepartmentConsulted = await connection.QueryFirstOrDefaultAsync
                        <AssetCategoryDepartment>(procedure, new
                    {
                        IdAsset = id
                    }, commandType: CommandType.StoredProcedure);
                    
                    return CatergoryDepartmentConsulted;

                } 
                
            }catch(SqlException e)
            {
                Console.WriteLine(e.ErrorCode.ToString());
                assetCategoryDepartment.AssetCategory = "NO Categoria";
                assetCategoryDepartment.AssetDepartment = "NO Departamento";
                return assetCategoryDepartment;
            }
        }
        public async Task<AssetAllinfoViewModel> GetAssetAllInfoByIdAsync(int Id)
        {
           
            
                AssetAllinfoViewModel assetAllinfoViewModel = new AssetAllinfoViewModel();
                assetAllinfoViewModel.assetUserProfileView = await GetAssetUserProfileAsync(Id);
                assetAllinfoViewModel.AssetConsultViewModel = await GetAssetByIdAsync(Id);
                assetAllinfoViewModel.AssetConsultViewModel.CategoryDisplay = (await GetAssetCategoryDepartmentAsync(Id)).AssetCategory;
                assetAllinfoViewModel.AssetConsultViewModel.DepartmentDisplay = (await GetAssetCategoryDepartmentAsync(Id)).AssetDepartment;
            
                    return assetAllinfoViewModel;
           
         
            


            
        }


    }
}
