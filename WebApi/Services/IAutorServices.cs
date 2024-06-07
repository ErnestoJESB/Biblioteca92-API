using Domain.Entities;

namespace WebApi.Services
{
    public interface IAutorServices
    {

        public Task<Response<List<Autor>>> GetAutores();
        public Task<Response<Autor>> Crear(Autor i);
        public Task<Response<Autor>> UpdateAutor(Autor i);
        public Task<Response<Autor>> DeleteAutor(int PKAutor);
        public Task<Response<Autor>> GetIdAutor(int PKAutor);


    }
}
