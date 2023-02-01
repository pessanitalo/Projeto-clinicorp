using ProjetoDemo;

namespace CliniCorp.Business.Interfaces
{
    public interface IConsultaRepository
    {
        Task<IEnumerable<Consulta>> ListarTodos();
        Task<IEnumerable<Consulta>> ListarDemo();
        Consulta AtualizarStatus(int id);
        Consulta Detalhes(int id);
        Consulta Adicionar(Consulta consulta, int pacienteId, int medicoId);
        Consulta AdicionarDemo(Consulta consulta);
        Consulta AtualizarStatus(Consulta consulta);
        Consulta AtualizarDataConsulta(Consulta consulta);
    }
}
