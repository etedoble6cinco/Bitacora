using BitacoraAPP.Models.EmpleadoUserViewModel;

namespace BitacoraAPP.Services.ActivationServices
{

    public interface IActivationGeneralReportService
    {
        Task<bool> ActivateGeneralReportService(List<ListarEmpleadosGeneralReport> ListaUsuarios);
    }
    public class ActivationGeneralReportService : IActivationGeneralReportService
    {
        private readonly IEmailService _emailService;    
        private readonly IExcellReportService _excellReportService;
        public ActivationGeneralReportService(IEmailService emailService ,IExcellReportService excellReport)
        {
            this._emailService = emailService;
            this._excellReportService = excellReport;   
        }
        public Task<bool> ActivateGeneralReportService(List<ListarEmpleadosGeneralReport> ListaUsuarios)
        {
            
            return false;
        }
    }
}
