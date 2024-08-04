using EntityLayer.Responses;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataBase
{
    internal class DatabaselibreriaContext
    {
        private readonly string ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
        private readonly SqlConnection Connection = new();
        private readonly Response Response = new();

        public Response DatabaseConnection
        {
            get
            {
                try
                {
                    Connection.ConnectionString = ConnectionString;
                    Connection.Open();

                    Response.Code = ResponseType.Success;
                    Response.Message = "Coneccion exitosa";
                    Response.Data = Connection;

                }
                catch (Exception ex)
                {
                    Response.Code = ResponseType.Error;
                    Response.Message = ex.Message;
                    Response.Data = ex.Data;

                    return Response;
                }
                return Response;
            }
        }
    }
}
