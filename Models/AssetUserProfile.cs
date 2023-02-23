namespace BitacoraAPP.Models
{
    public class AssetUserProfile :EntityBase
    {
        public string? FirstName { get; set; }   
        public string? LastName { get; set; }    
        public string? Email { get; set; }   
        public string? PhoneNumber { get; set; } 
        public string? EmployeeCode { get; set; }    
        public string? UserName { get; set; }
        public bool EmailConfirmed { get; set; }  
      
        public int AssignEmployeeId { get; set; } 
        public string? ProfilePicture { get; set; }  
        
    
    }
}
