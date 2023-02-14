using BitacoraAPP.Data;
using BitacoraAPP.Models.EmpleadoUserViewModel;
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
                    
                    foreach(var user in ListaUsuariosReport)
                    {
                        if (user.CerrarRegistro.Equals(""))
                        {
                            if (user.HoraEntrada.ToString() == "")
                            {
                                user.CerrarRegistro = 2;
                            }
                            else
                            {
                                user.CerrarRegistro = 0;
                            }
                           
                            
                        }
                        else
                        {
                            if(int.Parse(user.CerrarRegistro.ToString()) == 0)
                            {
                                user.CerrarRegistro = 0;
                            }
                            else
                            {
                                user.CerrarRegistro = 1;
                            }
                        }
                    }
                    return ListaUsuariosReport.ToList();
                }
            }catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                return new List<ListarEmpleadosGeneralReport>(); //RETURN EMPTY LIST
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
            try
            {
                var procedure = "getusuariosreport";
                using (var connection = new SqlConnection(connectionString))
                {
                    var ListaUsuarios = await connection.QueryAsync<ListaEmpleadosDashboard>(procedure,
                        commandType: System.Data.CommandType.StoredProcedure);

                    return ListaUsuarios.ToList();

                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                return new List<ListaEmpleadosDashboard>();
            
            }
           
               
        }
    }
}
