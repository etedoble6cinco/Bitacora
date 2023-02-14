using BitacoraAPP.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BitacoraAPP.Services
{
    public interface IUsuarioEmpleadoService
    {

        Task<List<Usuario>> GetUsuariosEmpleados();
        Task<Usuario> GetUsuarioEmpleadoById(int UserId);
        Task<bool> InsertUsuarioEmpleado(Usuario usuario);
        Task<bool> UpdateUsuarioEmpleado(Usuario usuario);
    }
    public class UsuarioEmpleadoService : IUsuarioEmpleadoService
    {
        private readonly string ConnectionString;
        public UsuarioEmpleadoService(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Usuario> GetUsuarioEmpleadoById(int Id)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))

                    return await connection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM Usuarios WHERE Id=@Id",
                        new { Id });

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                return new Usuario();
            }





        }

        public async Task<List<Usuario>> GetUsuariosEmpleados()
        {
            try
            {
                var query = "SELECT * FROM Usuario";
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var list = await connection.QueryAsync<Usuario>(query);

                    return list.ToList();
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                return new List<Usuario>();

            }

        }

        public async Task<bool> InsertUsuarioEmpleado(Usuario usuario)
        {

            var query = "INSERT INTO Usuario " +
                "(ClaveUsuario," +
                "NombreUsuario," +
                "TipoUsuario) VALUES" +
                "(@ClaveUsuario," +
                "@NombreUsuario," +
                "@TipoUsuario);";
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.ExecuteAsync(query, new
                    {
                        usuario.ClaveUsuario,
                        usuario.NombreUsuario,
                        usuario.TipoUsuario
                    });

                    return true;
                }
            }
            catch (SqlException e)
            {

                Console.WriteLine(e.Message.ToString());
                return false;
            }

        }
        public async Task<bool> UpdateUsuarioEmpleado(Usuario usuario)
        {
            try
            {
                var query = "UPDATE Usuarios SET " +
               "ClaveUsuario = @ClaveUsuario," +
               "NombreUsuario =@NombreUsuario," +
               "TipoUsuario=@TipoUsuario WHERE Id =@Id";
                using (var connection = new SqlConnection(ConnectionString))
                {
                    await connection.ExecuteAsync(query, new
                    {
                        usuario.ClaveUsuario,
                        usuario.NombreUsuario,
                        usuario.TipoUsuario
                    });
                    return true;
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                return false;
            }

        }
    }
}
