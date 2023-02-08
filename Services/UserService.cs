using BitacoraAPP.Data;
using BitacoraAPP.Models;

namespace BitacoraAPP.Services
{
   

    public interface IUserService
    {
        Task <Usuario> GetUsuarios();
        Task <Usuario> UpsertUsuarioById();
        Task <Usuario> DeleteUsuarioById();

    }
    public class UserService : IUserService
    {
        private readonly string ConnectionString;
        private readonly ApplicationDbContext _context;
        public UserService(IConfiguration configuration, ApplicationDbContext context)
        {
            this.ConnectionString = configuration.GetConnectionString("DefaultConnection");
            _context = context;
        }

        public Task<Usuario> DeleteUsuarioById()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> UpsertUsuarioById()
        {
            throw new NotImplementedException();
        }
    }
}
