using CliniCorp.Business.Models;
using ProjetoDemo;

namespace CliniCorp.Business.Interfaces
{
    public interface IConsultaRepository
    {
        Task<PageList<Consulta>> ListarTodos(PageParams pageParams);       
        Task<Consulta> Detalhes(int id);
        Task<Consulta> Adicionar(Consulta consulta);
        
        //corrigir!
        Consulta CancelarConsulta(int id);
        Consulta RemarcarConsulta(Consulta consulta, int id);
        Consulta BuscarporId(int id);
    }
}
