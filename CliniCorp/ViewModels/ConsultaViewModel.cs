using ProjetoDemo;

namespace CliniCorp.ViewModels
{
    public class ConsultaViewModel
    {
        public int MedicoId { get; set; }
        public DateTime dataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }
        public int StatusConsulta { get; set; }

        public Paciente Paciente { get; set; }
    }
}
