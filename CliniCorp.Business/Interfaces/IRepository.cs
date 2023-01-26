using ProjetoDemo;

namespace CliniCorp.Business.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Consulta>> ListarTodos();
        Task<IEnumerable<Consulta>> ListarDemo();
        Consulta AtualizarStatus(int id);
        Consulta Detalhes(int id);
        Consulta Adicionar(Consulta consulta);
        Consulta AtualizarStatus(Consulta consulta);
        Consulta AtualizarDataConsulta(Consulta consulta);

        //Medico
        Medico AdicionarMedico(Medico medico);
        Task<IEnumerable<Medico>> ListarMedicos();
        Medico buscarMedicoPorNome(string nome);
        Medico ListarTodosPacientesdoMedico(int id);

        //Paciente
        Task<IEnumerable<Paciente>> ListarPacientes();
    }
}
