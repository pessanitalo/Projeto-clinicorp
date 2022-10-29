using System.ComponentModel.DataAnnotations;

namespace ProjetoDemo
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Crm { get; set; }
        public string Cpf { get; set; }
        public Paciente Paciente { get; set; }
        public string Especializacao { get; set; }
    }
}
