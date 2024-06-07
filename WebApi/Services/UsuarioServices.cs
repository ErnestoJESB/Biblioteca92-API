using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;

namespace WebApi.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDBContext _context;

        public UsuarioServices(ApplicationDBContext context)
        {
            _context = context;
        }
        //Obtencion de todos los usuarios
        public async Task<Response<List<Usuario>>> GetUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.Include(y => y.Roles).ToListAsync();

                return new Response<List<Usuario>>(response);   
            }
            catch (Exception ex) 
            {
                throw new Exception("Sucedio un error catastrofico"+ex.Message);
            }
        }
        //Crear usuario
        public async Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    User = request.User,
                    Password = request.Password,
                    FkRol = request.FkRol
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<UsuariosResponse>(request);
            }
            catch (Exception ex) 
            {
                throw new Exception("Sucedio un error macabro"+ex.Message);
            }
        }
        //Actualizar usuario
        public async Task<Response<UsuariosResponse>> ActualizarUsuario(int id, UsuariosResponse request)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<UsuariosResponse>("No existe ese usuario");
                }

                usuario.Nombre = request.Nombre;
                usuario.User = request.User;
                usuario.Password = request.Password;
                usuario.FkRol = request.FkRol;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return new Response<UsuariosResponse>(request);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el usuario: " + ex.Message);
            }
        }
        // Eliminar usuario
        public async Task<Response<bool>> EliminarUsuario(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<bool>("No existe el usuario");
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return new Response<bool>(true);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario: " + ex.Message);
            }
        }
        
        public async Task<Response<Usuario>> GetByID(int id)
        {
            try
            {
                Usuario res = await _context.Usuarios.FirstOrDefaultAsync(x=> x.PkUsuario == id);

                return new Response<Usuario>(res);
            }
            catch (Exception ex) 
            {
            
            throw new Exception("Ocurrio un error"+ex.Message);
            }
        }
    }
}
