using DataLayer.DataBase;
using EntityLayer.Models.DTO;
using EntityLayer.Models.Mappers;
using EntityLayer.Responses;
using Microsoft.Data.SqlClient;

namespace DataLayer.Repositories.Prestamo
{
    public class PrestamoRepository: IPrestamoRepository
    {
        private readonly Libreria2DbContext _context;
        private readonly PrestamosCabeceraMapper prestamoMapper = new();
        private readonly Response response = new DatabaselibreriaContext().DatabaseConnection;
        private SqlConnection connection = new();
        SqlDataReader reader = null;

        public PrestamoRepository(Libreria2DbContext context)
        {
            _context = context;
        }

        public async Task<Response> ObtenerPrestamos(string? busqueda)
        {
            connection = (SqlConnection)response.Data!;

            try
            {
                SqlCommand command = new SqlCommand("SP_FILTRAR_PRESTAMO_ESTUDIANTE", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PV_BUSQUEDA", string.IsNullOrEmpty(busqueda) ? (object)DBNull.Value : busqueda);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<PrestamosVista> prestamos = new List<PrestamosVista>();

                while (await reader.ReadAsync())
                {
                    PrestamosVista prestamo = new PrestamosVista
                    {
                        IdPrestamo = Convert.ToInt32(reader["ID_PRESTAMO"]),
                        Nombres = reader["NOMBRES"].ToString(),
                        Cedula = reader["CEDULA"].ToString(),
                        Nombre = reader["NOMBRE"].ToString(),
                        FechaPrestamo = reader["FECHA_PRESTAMO"] != DBNull.Value ? Convert.ToDateTime(reader["FECHA_PRESTAMO"]) : (DateTime?)null,
                        FechaEstimadaDevolucion = reader["FECHA_ESTIMADA_DEVOLUCION"] != DBNull.Value ? Convert.ToDateTime(reader["FECHA_ESTIMADA_DEVOLUCION"]) : (DateTime?)null
                    };

                    prestamos.Add(prestamo);
                }

                if (prestamos.Count > 0)
                {
                    response.Code = ResponseType.Success;
                    response.Message = "Prestamos obtenidos correctamente";
                    response.Data = prestamos;
                }
                else
                {
                    response.Code = ResponseType.Error;
                    response.Message = "No hay Prestamos";
                }
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = $"No se pudieron obtener los prestamos: {ex.Message}";
                response.Data = ex.Data;
            }
            finally
            {
                connection.Close();
            }

            return response;
        }

        public async Task<Response> InsertarPrestamos(PrestamoDTO prestamoDTO)
        {
            connection = (SqlConnection)response.Data!;

            try
            {
                SqlCommand command = new SqlCommand("SP_PRESTAMO_INS", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PI_LIBRO", prestamoDTO.IdLibro);
                command.Parameters.AddWithValue("@PD_FECHA_SUPUESTA_DEVOLUCION", prestamoDTO.FechaEstimadaDevolucion);
                command.Parameters.AddWithValue("@PV_CORREO", prestamoDTO.Correo);
                command.Parameters.AddWithValue("@PV_CONTRASENIA", prestamoDTO.Contrasenia);

                int result = await command.ExecuteNonQueryAsync();

                if (result != 0)
                {
                    response.Code = ResponseType.Success;
                    response.Message = "Prestamo creado correctamente";
                    response.Data = String.Empty;
                    return response;
                }
                else
                {
                    response.Code = ResponseType.Error;
                    response.Message = "No se pudo crear el prestamo";
                    response.Data = String.Empty;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = $"No se pudo ingresar el prestamo: {ex.Message}";
                response.Data = ex.Data;
            }
            finally
            {
                connection.Close();
            }

            return response;
        }

        public async Task<Response> ConfirmarPrestamos(int idPrestamo)
        {
            connection = (SqlConnection)response.Data!;

            try
            {
                SqlCommand command = new SqlCommand("SP_PRESTAMO_UPD", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PI_ID_PRESTAMO", idPrestamo);

                int result = await command.ExecuteNonQueryAsync();

                if (result != 0)
                {
                    response.Code = ResponseType.Success;
                    response.Message = "Prestamo entregado correctamente";
                    response.Data = String.Empty;
                    return response;
                }
                else
                {
                    response.Code = ResponseType.Error;
                    response.Message = "No se pudo entregar el prestamo";
                    response.Data = String.Empty;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = $"No se pudo ingresar el prestamo: {ex.Message}";
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
