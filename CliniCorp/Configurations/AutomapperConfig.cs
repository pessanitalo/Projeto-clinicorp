using AutoMapper;
using CliniCorp.ViewModels;
using ProjetoDemo;

namespace CliniCorp.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Consulta, ConsultaViewModel>().ReverseMap();
            CreateMap<Medico, MedicoViewModel>().ReverseMap();
            CreateMap<Paciente, PacienteViewModel>().ReverseMap();
        }
    }
}
