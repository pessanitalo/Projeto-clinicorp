using ProjetoDemo;

namespace CliniCorp.Business.Models
{
    public class consultaLista
    {
        public int Id { get; set; }
        public DateTime dataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }
        public int StatusConsulta { get; set; }
        public string Nome { get; set; }
        public string NomePaciente { get; set; }
        public string Especializacao { get; set; }

    }
}
