using System.ComponentModel.DataAnnotations;

namespace CliniCorp.ViewModels
{
    public class CreateConsultaViewModel
    {
        public int pacienteId { get; set; }
        public int medicoId { get; set; }
        public DateTime DataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }

    }
}
