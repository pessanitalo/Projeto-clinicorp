using ProjetoDemo;


namespace CliniCorp.Business.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> ListarPacientes();
        Task<Paciente> Adicionarpaciente(Paciente paciente);
        Task<Paciente> buscarPacientePorNome(string nome);
    }
}
