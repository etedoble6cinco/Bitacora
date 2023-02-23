namespace BitacoraAPP.Models.EmpleadoUserViewModel
{
    public class ListarEmpleadosGeneralReport
    {
        public int IdMovimientos { get; set; }
        public string ClaveUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string HoraSalida { get; set; }
        public string HoraEntrada { get; set; }
        public string DuracionMinutos { get; set; }
        public int IdUsuario { get; set; }
        public int CerrarRegistro { get; set; } = 0;
    }
}
