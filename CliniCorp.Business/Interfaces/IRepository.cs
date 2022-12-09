using CliniCorp.Business.Models;

namespace CliniCorp.Business.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<consultaLista>> ListarTodos();
    }
}
