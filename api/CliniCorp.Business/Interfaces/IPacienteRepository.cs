using CliniCorp.Business.Models;
using ProjetoDemo;


namespace CliniCorp.Business.Interfaces
{
    public interface IPacienteRepository
    {
        Task<PageList<Paciente>> ListarPacientes(PageParams pageParams);
        Task<Paciente> Adicionarpaciente(Paciente paciente);
        Task<Paciente> buscarPacientePorNome(string nome, string cpf);
        Paciente pesquisarPaciente(int id);
    }
}
