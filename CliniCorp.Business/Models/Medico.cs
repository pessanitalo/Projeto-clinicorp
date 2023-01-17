namespace ProjetoDemo
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public string Cpf { get; set; }
        public string Especializacao { get; set; }

        public IEnumerable<Paciente> Pacientes { get; set; }
    }
}
