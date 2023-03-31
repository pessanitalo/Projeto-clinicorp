using CliniCorp.Business.Models;

namespace ProjetoDemo
{
    public class Medico : Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Especializacao { get; set; }
    }
}
