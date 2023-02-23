namespace BitacoraAPP.Models
{
    public class EmailConfiguration
    {
        public string from { get; set; } = "analista.sistemas@smimx.net";
        public string to { get; set; } = "aplumeda@smimx.net";
        public string SmtpServer { get; set; } = "smtp.office365.com";
        public int Port { get; set; } = 587;
        public string UserName { get; set; } = "analista.sistemas@smimx.net";
        public string Password { get; set; } = "Suq70797";
        public string EmailHeader { get; set; } = "REPORTE SMI DE E/S";
        public string EmailSubject { get; set; } = "SMI REPORTE GENERAL DE ENTRADAS & SALIDAS DE EMPLEADOS";

    }
}


