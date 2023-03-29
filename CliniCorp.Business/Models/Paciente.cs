using CliniCorp.Business.Models;

namespace ProjetoDemo
{
    public class Paciente : Pessoa
    {  
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
    }
}
