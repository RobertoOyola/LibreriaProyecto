using DataLayer.DataBase;
using EntityLayer.Models.DTO;
using EntityLayer.Models.Entities;
using EntityLayer.Models.Mappers;
using EntityLayer.Responses;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Autor
{
    public class AutorRepository : IAutorRepository
    {
        private readonly Libreria2DbContext _context;
        private readonly AutorMapper productoMapper = new();
        private readonly Response response = new DatabaselibreriaContext().DatabaseConnection;
        private SqlConnection connection = new();
        SqlDataReader reader = null;

        public AutorRepository(Libreria2DbContext context)
        {
            _context = context;
        }

        public async Task<Response> ObtenerAutores()
        {
            connection = (SqlConnection)response.Data!;

            try
            {
                SqlCommand command = new SqlCommand("SP_AUTOR_GET", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<AutorDTO> autores = new List<AutorDTO>();

                while (await reader.ReadAsync())
                {
                    AutorDTO autor = new AutorDTO
                    {
                        IdAutor = Convert.ToInt32(reader["ID_AUTOR"]),
                        NombreAutor = reader["NOMBRE_AUTOR"].ToString(),
                        Estado = reader["ESTADO"].ToString(),
                    };

                    autores.Add(autor);
                }
                if (autores.Count > 0)
                {
                    response.Code = ResponseType.Success;
                    response.Message = "Autores obtenidos correctamente";
                    response.Data = autores;
                }
                else
                {
                    response.Code = ResponseType.Error;
                    response.Message = $"No se pudieron obtener los autores";
                }
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = $"No se pudieron obtener los autores {ex.Message}";
                response.Data = ex.Data;
            }
            finally
            {
                connection.Close();
            }

            return response;
        }
    }
}
