namespace ProjetoDemo
{
    public class Consulta
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }
        public DateTime dataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }
        public int StatusConsulta { get; set; }

        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}
