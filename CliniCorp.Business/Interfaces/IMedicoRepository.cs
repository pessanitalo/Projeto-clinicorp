using ProjetoDemo;

namespace CliniCorp.Business.Interfaces
{
    public interface IMedicoRepository
    {
        Medico AdicionarMedico(Medico medico);
        Task<IEnumerable<Medico>> ListarMedicos();
        Medico buscarMedicoPorNome(string nome);
        Medico ListarTodosPacientesdoMedico(int id);
    }
}
