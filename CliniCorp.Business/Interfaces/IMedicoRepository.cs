using ProjetoDemo;

namespace CliniCorp.Business.Interfaces
{
    public interface IMedicoRepository
    {
        Task<Medico> AdicionarMedico(Medico medico);
        Task<IEnumerable<Medico>> ListarMedicos();
        Task<Medico> buscarMedicoPorNome(string nome);
        //Montar a query para adicnionar os pacientes
        Medico ListarTodosPacientesdoMedico(int id);
    }
}
