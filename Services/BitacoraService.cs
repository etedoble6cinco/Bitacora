using BitacoraAPP.Data;
using BitacoraAPP.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BitacoraAPP.Services
{
    public interface IBitacoraService
    {  
        Task<bool> InsertCorteBitacoraService();
        Task<List<ListarEmpleadosGeneralReport>> GetReporteBitacoraService();
        Task <List<ListaEmpleadosDashboard>> GetDashboardBitacoraService();
    }
    public class BitacoraService : IBitacoraService
    {
        private readonly string connectionString;

      
        public BitacoraService(IConfiguration configuration)
        {
            
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<ListarEmpleadosGeneralReport>> GetReporteBitacoraService()
        {

            var procedure = "getusuariosreport2";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var ListaUsuariosReport = await connection.QueryAsync<ListarEmpleadosGeneralReport>(procedure,
                        commandType: System.Data.CommandType.StoredProcedure);
                    return ListaUsuariosReport.ToList();
                }
            }catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                return new List<ListarEmpleadosGeneralReport>();
            }
            
         
        }

        public async Task<bool> InsertCorteBitacoraService()
        {
            try
            {
                var procedure = "CrearCorteUsuarios";

                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.QueryAsync(procedure, commandType: System.Data.CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                return false;
            }
            
          
        }

        public async Task<List<ListaEmpleadosDashboard>> GetDashboardBitacoraService()
        {
            var procedure = "getusuariosreport";
            using (var connection = new SqlConnection(connectionString))
            {
            var ListaUsuarios = await connection.QueryAsync<ListaEmpleadosDashboard>(procedure,
                commandType: System.Data.CommandType.StoredProcedure);

                return ListaUsuarios.ToList();
            
            }
               
        }
    }
}
