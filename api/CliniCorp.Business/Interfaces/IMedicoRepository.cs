using CliniCorp.Business.Models;
using ProjetoDemo;

namespace CliniCorp.Business.Interfaces
{
    public interface IMedicoRepository
    {
        Task<PageList<Medico>> ListarMedicos(PageParams pageParams);
        Task<Medico> AdicionarMedico(Medico medico);        
        Task<Medico> buscarMedicoPorNome(string nome);

        IEnumerable<ListMedicoPaientes> ListarTodosPacientesdoMedico(int id);
        Medico buscarMedico(int id);
    }
}
