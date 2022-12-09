using System.ComponentModel.DataAnnotations;

namespace ProjetoDemo
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string  Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
    }
}
