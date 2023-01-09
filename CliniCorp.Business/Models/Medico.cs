namespace ProjetoDemo
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Crm { get; set; }
        public string Cpf { get; set; }
        public string Especializacao { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}
