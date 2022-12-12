using System.ComponentModel.DataAnnotations;

namespace ProjetoDemo
{
    public class Consulta
    {
        [Key]
        public int Id { get; set; }
        public Paciente? Paciente { get; set; }
        public Medico? Medico { get; set; }
        public DateTime dataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }
        public int StatusConsulta { get; set; }
    }
}
