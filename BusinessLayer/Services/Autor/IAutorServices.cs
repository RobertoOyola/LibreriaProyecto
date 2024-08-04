using EntityLayer.Responses;

namespace BusinessLayer.Services.Autor
{
    public interface IAutorServices
    {
        public Task<Response> ObtenerAutores();
    }
}
