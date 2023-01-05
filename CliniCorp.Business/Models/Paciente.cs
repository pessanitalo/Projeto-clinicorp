namespace ProjetoDemo
{
    public class Paciente
    {
     
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }

        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        //public int ConsultaId { get; set; }
        public Consulta Consulta { get; set; }


    }
}
