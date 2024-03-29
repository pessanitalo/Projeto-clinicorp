﻿namespace CliniCorp.ViewModels
{
    public class DetalhesConsultaViewModel
    {
        public int Id { get; set; }
        public DateTime dataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }
        public int Status { get; set; }

        public PacienteViewModel Paciente { get; set; }
        public MedicoViewModel Medico { get; set; }
    }
}
