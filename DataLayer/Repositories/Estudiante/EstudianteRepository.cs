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

namespace DataLayer.Repositories.Estudiante
{
    public class EstudianteRepository: IEstudianteRepository
    {
        private readonly Libreria2DbContext _context;
        private readonly EstudianteMapper estudianteMapper = new();
        private readonly Response response = new DatabaselibreriaContext().DatabaseConnection;
        private SqlConnection connection = new();
        SqlDataReader reader = null;

        public EstudianteRepository(Libreria2DbContext context)
        {
            _context = context;
        }

        public async Task<Response> InsertarEstudiante(EstudianteDTO estudianteDTO)
        {
            connection = (SqlConnection)response.Data!;

            try
            {
                SqlCommand command = new SqlCommand("SP_ESTUDIANTE_INS", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PV_CEDULA", estudianteDTO.Cedula);
                command.Parameters.AddWithValue("@PV_CORREO", estudianteDTO.Correo);
                command.Parameters.AddWithValue("@PV_CONTRASENIA", estudianteDTO.Contrasenia);
                command.Parameters.AddWithValue("@PV_NOMBRES", estudianteDTO.Nombres);

                int result = await command.ExecuteNonQueryAsync();

                if (result != 0)
                {
                    response.Code = ResponseType.Success;
                    response.Message = "Estudiante creado correctamente";
                    response.Data = String.Empty;
                    return response;
                }
                else
                {
                    response.Code = ResponseType.Error;
                    response.Message = "No se pudo crear al Estudiante";
                    response.Data = String.Empty;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = $"No se pudo ingresar al Estudiante {ex.Message}";
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
