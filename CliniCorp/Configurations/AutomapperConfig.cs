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
        }
    }
}
