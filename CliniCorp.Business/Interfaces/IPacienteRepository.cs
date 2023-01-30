using ProjetoDemo;


namespace CliniCorp.Business.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> ListarPacientes();
    }
}
