namespace BitacoraAPP.Models
{
    public class EmailConfiguration
    {
        public string from { get; set; }    
        public string to { get; set; }  
        public string SmtpServer { get; set; }  
        public int Port { get; set; }   
        public string UserName { get; set; }
        public string Password { get; set; }    
        public string EmailHeader { get; set; }
        public string EmailSubject { get; set; }    
        public string EmailFileLocation { get; set; }
    }
}
