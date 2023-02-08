namespace BitacoraAPP.Services
{
    public interface IExcellReportService
    {
        Task<int> CreateExcellGeneralReportService();
       
    }
    public class ExcellReportService :IExcellReportService
    {
       public async Task<int> CreateExcellGeneralReportService()
       {
            return 0;
       } 
    }
}
