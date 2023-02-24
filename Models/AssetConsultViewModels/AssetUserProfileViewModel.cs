using System.ComponentModel.DataAnnotations;

namespace BitacoraAPP.Models.AssetConsultViewModels
{
    public class AssetUserProfileViewModel
    {

        [Display(Name = "Employee Full Name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Display(Name ="Email SMI")]
        public string Email { get; set; }
        [Display(Name="Num Extension")]
        public string PhoneNumber { get; set; }
        [Display(Name ="Employee Code")]
        public string EmployeeCode { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; }

        public int AssignEmployeeId { get; set; }
        public string ProfilePicture { get; set; }
        [Display(Name ="Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        public bool Cancelled { get; set; }
    }
}
