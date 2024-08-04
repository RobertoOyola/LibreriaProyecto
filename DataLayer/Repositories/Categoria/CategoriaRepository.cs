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

namespace DataLayer.Repositories.Categoria
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly Libreria2DbContext _context;
        private readonly CategoriaMapper categoriaMapper = new();
        private readonly Response response = new DatabaselibreriaContext().DatabaseConnection;
        private SqlConnection connection = new();
        SqlDataReader reader = null;

        public CategoriaRepository(Libreria2DbContext context)
        {
            _context = context;
        }

        public async Task<Response> ObtenerCategorias()
        {
            connection = (SqlConnection)response.Data!;

            try
            {
                SqlCommand command = new SqlCommand("SP_CATEGORIAS_GET", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<CategoriaDTO> categorias = new List<CategoriaDTO>();

                while (await reader.ReadAsync())
                {
                    CategoriaDTO categoria = new CategoriaDTO
                    {
                        IdCategoria = Convert.ToInt32(reader["ID_CATEGORIA"]),
                        DescripcionCategoria = reader["DESCRIPCION_CATEGORIA"].ToString(),
                        Estado = reader["ESTADO"].ToString(),
                    };

                    categorias.Add(categoria);
                }
                if (categorias.Count > 0)
                {
                    response.Code = ResponseType.Success;
                    response.Message = "Categorias obtenidas correctamente";
                    response.Data = categorias;
                }
                else
                {
                    response.Code = ResponseType.Error;
                    response.Message = $"No se pudieron obtener las categorias";
                }
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = $"No se pudieron obtener las categorias {ex.Message}";
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
