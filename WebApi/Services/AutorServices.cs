using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Context;

namespace WebApi.Services
{
    public class AutorServices : IAutorServices
    {
        private readonly ApplicationDBContext _context;
        public AutorServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> respose = new List<Autor>();

                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new { }, commandType: CommandType.StoredProcedure);

                respose = result.ToList();

                return new Response<List<Autor>>(respose);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico" + ex.Message);
            }
        }

        public async Task<Response<Autor>> Crear(Autor i)
        {
            try
            {
                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new { i.Nombre, i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<Autor>(result);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico" + ex.Message);
            }
        } 

        public async Task<Response<Autor>> UpdateAutor(Autor i)
        {
            try
            {
                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spUpdateAutor", new { i.PKAutor, i.Nombre, i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<Autor>(result);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico" + ex.Message);
            }
        }

        public async Task<Response<Autor>> DeleteAutor(int PKAutor)
        {
            try
            {
                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spDeleteAutor", new { PKAutor }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<Autor>(result);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico" + ex.Message);
            }
        }

        public async Task<Response<Autor>> GetIdAutor(int PKAutor)
        {
            try
            {
                List<Autor> respose = new List<Autor>();

                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetIdAutor", new { PKAutor }, commandType: CommandType.StoredProcedure);

                respose = result.ToList();

                return new Response<Autor>(respose.FirstOrDefault());

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico" + ex.Message);
            }
        }
    }
}
