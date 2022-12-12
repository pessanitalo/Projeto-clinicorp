using CliniCorp.Business.Models;
using ProjetoDemo;

namespace CliniCorp.Business.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<consultaLista>> ListarTodos();
        Consulta BuscarPorId(int id);
        Consulta Adicionar(Consulta consulta);

    }
}
