namespace BitacoraAPP.Models
{
    public class ListarEmpleadosGeneralReport
    {
        public int IdMovimientos { get; set; }  
        public string ClaveUsuarios { get; set; }
        public string NombreUsuarios { get; set; }
        public string HoraSalida { get; set; }
        public string HoraEntrada { get; set; }
        public string DuracionMinutos { get; set; } 
        public int IdUsuario { get; set; }
        public int CerrarRegistro { get; set; }
    }
}
