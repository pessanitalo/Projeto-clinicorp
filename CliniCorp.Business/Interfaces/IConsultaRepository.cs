using ProjetoDemo;

namespace CliniCorp.Business.Interfaces
{
    public interface IConsultaRepository
    {
        Task<IEnumerable<Consulta>> ListarTodos();       
        Task<Consulta> Detalhes(int id);
        Task<Consulta> Adicionar(Consulta consulta);
        //corrigir!
        Consulta AtualizarStatus(int id);
        Consulta AtualizarStatus(Consulta consulta);
        Consulta AtualizarDataConsulta(Consulta consulta);
    }
}
