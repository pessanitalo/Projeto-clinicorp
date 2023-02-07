using ProjetoDemo;

namespace CliniCorp.Business.Interfaces
{
    public interface IConsultaRepository
    {
        Task<IEnumerable<Consulta>> ListarTodos();       
        Task<Consulta> Detalhes(int id);
        Task<Consulta> Adicionar(Consulta consulta);
        
        //corrigir!
        Consulta CancelarConsulta(Consulta consulta);
        Consulta RemarcarConsulta(Consulta consulta, int id);
        Consulta BuscarporId(int id);
    }
}
