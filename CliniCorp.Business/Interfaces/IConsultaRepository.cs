using ProjetoDemo;

namespace CliniCorp.Business.Interfaces
{
    public interface IConsultaRepository
    {
        Task<IEnumerable<Consulta>> ListarTodos();
        Consulta AtualizarStatus(int id);
        Task<Consulta> Detalhes(int id);
        Task<Consulta> Adicionar(Consulta consulta);
        Consulta AtualizarStatus(Consulta consulta);
        Consulta AtualizarDataConsulta(Consulta consulta);
    }
}
