using AutoMapper;
using CliniCorp.ViewModels;
using ProjetoDemo;

namespace CliniCorp.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Consulta, CreateConsultaViewModel>().ReverseMap();
            CreateMap<Consulta, DetalhesConsultaViewModel>().ReverseMap();
            CreateMap<Consulta, ListConsultaViewModel>().ReverseMap();

            CreateMap<Medico, MedicoViewModel>().ReverseMap();
            CreateMap<Medico, ListMedicoViewModel>().ReverseMap();
            CreateMap<Medico, CreateMedicoViewModel>().ReverseMap();

            CreateMap<Paciente, PacienteViewModel>().ReverseMap();
            CreateMap<Paciente, ListPacienteViewModel>().ReverseMap();
       
        }
    }
}
