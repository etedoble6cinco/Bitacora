using System.ComponentModel.DataAnnotations;

namespace BitacoraAPP.Models.AssetConsultViewModels
{
    public class AssetUserProfileViewModel
    {

        [Display(Name = "Nombre de Empleado Asignado")]
        public string FirstName { get; set; }
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Display(Name ="Email SMI")]
        public string Email { get; set; }
        [Display(Name="Num Extension")]
        public string PhoneNumber { get; set; }
        [Display(Name ="Codigo de Empleado")]
        public string EmployeeCode { get; set; }
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; }

        public int AssignEmployeeId { get; set; }
        public string ProfilePicture { get; set; }
        [Display(Name ="Fecha de Creacion")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Fecha de Modificacion")]
        public DateTime ModifiedDate { get; set; }
        [Display(Name = "Creado por")]
        public string CreatedBy { get; set; }
        
        [Display(Name = "Modificado por")]
        public string ModifiedBy { get; set; }
        public bool Cancelled { get; set; }
    }
}
