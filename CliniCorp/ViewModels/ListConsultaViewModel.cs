namespace CliniCorp.ViewModels
{
    public class ListConsultaViewModel
    {
        public int Id { get; set; }
        public DateTime dataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }
        public int Status { get; set; }
        public string StatusConsulta { get; set; }

        public ListPacienteViewModel Paciente { get; set; }
        public ListMedicoViewModel Medico { get; set; }
    }
}
