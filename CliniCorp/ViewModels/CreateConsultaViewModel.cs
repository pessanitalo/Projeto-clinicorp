using System.ComponentModel.DataAnnotations;

namespace CliniCorp.ViewModels
{
    public class CreateConsultaViewModel
    {
        //public int Id { get; set; }

        //public int Medico_id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime dataConsulta { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string DescricaoConsulta { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int StatusConsulta { get; set; }

        public PacienteViewModel Paciente { get; set; }

    }
}
