namespace CliniCorp.ViewModels
{
    public class ListViewModel
    {
        public int Id { get; set; }
        public DateTime dataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }
        public int StatusConsulta { get; set; }

        public PacienteViewModel Paciente { get; set; }
        public MedicoViewModel Medico { get; set; }
    }
}
