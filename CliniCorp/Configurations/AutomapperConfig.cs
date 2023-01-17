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
            CreateMap<Consulta, ListViewModel>().ReverseMap();
            CreateMap<Medico, MedicoViewModel>().ReverseMap();
            CreateMap<Paciente, PacienteViewModel>().ReverseMap();

            //testes
            CreateMap<Consulta, ListConsultaViewModel>().ReverseMap();
            CreateMap<Medico, ListMedicoViewModel>().ReverseMap();
            CreateMap<Paciente, ListPacienteViewModel>().ReverseMap();

            //
            CreateMap<Medico, CreateMedicoViewModel>().ReverseMap();
        }
    }
}
