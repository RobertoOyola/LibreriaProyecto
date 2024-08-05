using DataLayer.DataBase;
using EntityLayer.Models.DTO;
using EntityLayer.Models.Mappers;
using EntityLayer.Responses;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Response> ObtenerPrestamos()
        {
            connection = (SqlConnection)response.Data!;

            try
            {
                SqlCommand command = new SqlCommand("SP_PRESTAMOS_SHOWS", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<PrestamosVista> prestamos = new List<PrestamosVista>();

                while (await reader.ReadAsync())
                {
                    PrestamosVista prestamo = new PrestamosVista
                    {
                        IdPrestamo = Convert.ToInt32(reader["ID_PRESTAMO"]),
                        IdEstudiante = Convert.ToInt32(reader["ID_ESTUDIANTE"]),
                        IdLibro = Convert.ToInt32(reader["ID_LIBRO"]),
                        FechaPrestamo = Convert.ToDateTime(reader["FECHA_PRESTAMO"]),
                        FechaEstimadaDevolucion = Convert.ToDateTime(reader["FECHA_ESTIMADA_DEVOLUCION"]),
                        Estado = reader["ESTADO"].ToString(),
                        Nombre = reader["NOMBRE"].ToString(),
                        Nombres = reader["NOMBRES"].ToString()
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
                response.Message = $"No se pudieron obtener los prestamos {ex.Message}";
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
