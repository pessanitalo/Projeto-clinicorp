namespace CliniCorp.ViewModels
{
    public class CreateConsultaViewModel
    {
        public int Id { get; set; }

        //public int Medico_id { get; set; }
        public DateTime dataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }
        public int StatusConsulta { get; set; }

        public PacienteViewModel Paciente { get; set; }

    }
}
