namespace ProjetoDemo
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime DataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }
        public int Status { get; set; }
        public string StatusConsulta { get; set; }

        public Medico? Medico { get; set; }
        public Paciente? Paciente { get; set; }

    }
}
