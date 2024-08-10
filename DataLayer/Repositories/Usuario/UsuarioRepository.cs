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

namespace DataLayer.Repositories.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Libreria2DbContext _context;
        private readonly UsuarioMapper usuarioMapper = new();
        private readonly Response response = new DatabaselibreriaContext().DatabaseConnection;
        private SqlConnection connection = new();
        SqlDataReader reader = null;

        public UsuarioRepository(Libreria2DbContext context)
        {
            _context = context;
        }

        public async Task<Response> LoginUsuario(LoginUsuario loginUsuario)
        {
            connection = (SqlConnection)response.Data!;

            try
            {
                SqlCommand command = new SqlCommand("SP_USUARIO_LOGIN", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PV_CORREO", loginUsuario.Correo);
                command.Parameters.AddWithValue("@PV_CONTRASENIA", loginUsuario.Contrasenia);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<UsuarioDTO> usuarios = new List<UsuarioDTO>();

                while (await reader.ReadAsync())
                {
                    UsuarioDTO usuario = new UsuarioDTO
                    {
                        IdUsuario = Convert.ToInt32(reader["ID_USUARIO"]),
                        Cedula = reader["CEDULA"].ToString(),
                        Correo = reader["CORREO"].ToString(),
                        Nombres = reader["NOMBRES"].ToString(),
                        Estado = reader["ESTADO"].ToString()
                    };

                    usuarios.Add(usuario);
                }

                if (usuarios.Count > 0)
                {
                    response.Code = ResponseType.Success;
                    response.Message = "Login Exitoso";
                    response.Data = usuarios;

                }
                else
                {
                    response.Code = ResponseType.Error;
                    response.Message = "Credenciales Incorrectas";
                }
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = $"Usuario no encontrado {ex.Message}";
                response.Data = ex.Data;
            }
            finally
            {
                connection.Close();
            }

            return response;
        }

        public async Task<Response> InsertarUsuario(UsuarioDTO usuarioDTO)
        {
            connection = (SqlConnection)response.Data!;

            try
            {
                SqlCommand command = new SqlCommand("SP_USUARIO_INS", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PV_CEDULA", usuarioDTO.Cedula);
                command.Parameters.AddWithValue("@PV_CORREO", usuarioDTO.Correo);
                command.Parameters.AddWithValue("@PV_CONTRASENIA", usuarioDTO.Contrasenia);
                command.Parameters.AddWithValue("@PV_NOMBRES", usuarioDTO.Nombres);

                int result = await command.ExecuteNonQueryAsync();

                if (result != 0)
                {
                    response.Code = ResponseType.Success;
                    response.Message = "Administrador creado correctamente";
                    response.Data = String.Empty;
                    return response;
                }
                else
                {
                    response.Code = ResponseType.Error;
                    response.Message = "No se pudo crear al Administrador";
                    response.Data = String.Empty;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = $"No se pudo ingresar al Admin {ex.Message}";
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
