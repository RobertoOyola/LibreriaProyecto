using DataLayer.DataBase;
using EntityLayer.Models.DTO;
using EntityLayer.Models.Mappers;
using EntityLayer.Responses;
using Microsoft.Data.SqlClient;

namespace DataLayer.Repositories.Libro
{
    public class LibroRepository : ILibroRepository
    {
        private readonly Libreria2DbContext _context;
        private readonly LibroMapper libroMapper = new();
        private readonly Response response = new DatabaselibreriaContext().DatabaseConnection;
        private SqlConnection connection = new();
        SqlDataReader reader = null;

        public LibroRepository(Libreria2DbContext context)
        {
            _context = context;
        }


        public async Task<Response> ObtenerLibroFiltro(FiltroLibros filtroLibros)
        {
            connection = (SqlConnection)response.Data!;

            try
            {
                SqlCommand command = new SqlCommand("SP_LIBROS_GET_FILTROS", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PV_BUSQUEDA", (object)filtroLibros.Busqueda ?? DBNull.Value);
                command.Parameters.AddWithValue("@PI_ID_AUTOR", filtroLibros.IdAutor == 0 ? DBNull.Value : (object)filtroLibros.IdAutor);
                command.Parameters.AddWithValue("@PI_ID_CATEGORIA", filtroLibros.IdCategoria == 0 ? DBNull.Value : (object)filtroLibros.IdCategoria);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<LibrosFiltrados> libros = new List<LibrosFiltrados>();

                while (await reader.ReadAsync())
                {
                    LibrosFiltrados libro = new LibrosFiltrados
                    {
                        IdLibro = Convert.ToInt32(reader["ID_LIBRO"]),
                        Nombre = reader["NOMBRE"].ToString(),
                        NombreAutor = reader["NOMBRE_AUTOR"].ToString(),
                        TotalStock = Convert.ToInt32(reader["TOTAL_STOCK"]),
                        AnioPublicacion = reader["ANIO_PUBLICACION"].ToString(),
                        DescripcionCategoria = reader["DESCRIPCION_CATEGORIA"].ToString()
                    };

                    libros.Add(libro);
                }

                if (libros.Count > 0)
                {
                    response.Code = ResponseType.Success;
                    response.Message = "Libros obtenidos correctamente";
                    response.Data = libros;
                }
                else
                {
                    response.Code = ResponseType.Error;
                    response.Message = "No hay libros con los filtros puestos";
                }
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = $"No se pudieron obtener los libros {ex.Message}";
                response.Data = ex.Data;
            }
            finally
            {
                connection.Close();
            }

            return response;
        }


        public async Task<Response> CrearLibro(LibroCrear libro)
        {
            connection = (SqlConnection)response.Data!;

            try
            {
                SqlCommand command = new SqlCommand("SP_LIBRO_CREAR", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PV_NOMBRE_LIBRO", libro.Nombre);
                command.Parameters.AddWithValue("@PV_ANIO_PUBLICACION", libro.AnioPublicacion);
                command.Parameters.AddWithValue("@PV_NOMBRE_AUTOR", libro.NombreAutor);
                command.Parameters.AddWithValue("@PI_TOTAL_STOCK", libro.TotalStock);
                command.Parameters.AddWithValue("@PV_DESCRIPCION_CATEGORIA", libro.DescripcionCategoria);

                int result = await command.ExecuteNonQueryAsync();

                if (result != 0)
                {
                    response.Code = ResponseType.Success;
                    response.Message = "Libro creado correctamente";
                    response.Data = String.Empty;
                    return response;
                }
                else
                {
                    response.Code = ResponseType.Error;
                    response.Message = "No se pudo crear el libro";
                    response.Data = String.Empty;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = $"No se pudo ingresar el Libro {ex.Message}";
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
