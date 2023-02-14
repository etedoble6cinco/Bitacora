using BitacoraAPP.Models;
using BitacoraAPP.Models.EmpleadoUserViewModel;

namespace BitacoraAPP.Services.ActivationServices
{

    public interface IActivationGeneralReportService
    {
        Task<bool> ActivateGeneralReportService();
    }
    public class ActivationGeneralReportService : IActivationGeneralReportService
    {
        private readonly IBitacoraService _bitacoraService; 
        private readonly IEmailService _emailService;    
        private readonly IExcellReportService _excellReportService;
        public ActivationGeneralReportService(IEmailService emailService ,IExcellReportService excellReport ,
            IBitacoraService bitacoraService)

        {
            this._emailService = emailService;
            this._excellReportService = excellReport;
            this._bitacoraService = bitacoraService;
        }

        public async Task<bool> ActivateGeneralReportService()
        {
            EmailConfiguration email = new EmailConfiguration();
            
            var EmployeeList = await _bitacoraService.GetReporteBitacoraService();
            string ExcelReport = await _excellReportService.CreateExcellGeneralReportService(EmployeeList);
            await _emailService.SendEmailFileAsyncService(email,ExcelReport);

            return true;
        }
    }
}
