﻿namespace ProjetoDemo
{
    public class Paciente
    {
        public int MedicoId { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }

        public Medico Medico { get; set; }
    }
}
