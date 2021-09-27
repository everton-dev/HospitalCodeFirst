using AutoMapper;
using Hospital.Domain.Entidades;
using Hospital.UI.MVC.Models;

namespace Hospital.UI.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ExameViewModel, Exame>().ForMember(c => c.TipoExame, m => m.MapFrom(a => new TipoExame(a.TipoExameId, "", "")));
            CreateMap<Exame, ExameViewModel>().ForMember(c => c.TipoExameId, m => m.MapFrom(a => a.TipoExame.Id));
        }
    }
}