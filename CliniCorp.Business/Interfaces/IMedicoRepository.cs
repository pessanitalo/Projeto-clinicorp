using CliniCorp.Business.Models;
using ProjetoDemo;

namespace CliniCorp.Business.Interfaces
{
    public interface IMedicoRepository
    {
        Task<Medico> AdicionarMedico(Medico medico);
        Task<IEnumerable<Medico>> ListarMedicos();
        Task<Medico> buscarMedicoPorNome(string nome);

        IEnumerable<ListMedicoPaientes> ListarTodosPacientesdoMedico(int id);
        Medico buscarMedico(int id);
    }
}
