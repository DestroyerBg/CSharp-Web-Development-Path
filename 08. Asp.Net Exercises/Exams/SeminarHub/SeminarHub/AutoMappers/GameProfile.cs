using System.Globalization;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
using SeminarHub.Constraints;
using SeminarHub.Data.DatabaseModels;
using SeminarHub.Models.ViewModels;

namespace SeminarHub.AutoMappers
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<AddSeminarViewModel, Seminar>()
                .ForMember(dest => dest.DateAndTime, opt =>
                    opt.MapFrom(m => DateTime.ParseExact(m.DateAndTime, SeminarConstraints.DateAndTimeFormat,
                        CultureInfo.InvariantCulture, DateTimeStyles.None)));

            CreateMap<Seminar, EditSeminarViewModel>()
                .ForMember(dest => dest.DateAndTime, opt =>
                    opt.MapFrom(m => m.DateAndTime.ToString(SeminarConstraints.DateAndTimeFormat, CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.OrganizerId, src =>
                    src.MapFrom(s => s.Organizer.Id));

            CreateMap<Seminar, AllSeminarsViewModel>()
                .ForMember(dest => dest.DateAndTime, s =>
                    s.MapFrom(sm => sm.DateAndTime.ToString(SeminarConstraints.DateAndTimeFormat, CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Category, s =>
                    s.MapFrom(sm => sm.Category.Name))
                .ForMember(dest => dest.Organizer, src => 
                    src.MapFrom(s => s.Organizer.UserName));

            CreateMap<Seminar, SeminarDetailsViewModel>()
                .ForMember(dest => dest.DateAndTime, s =>
                    s.MapFrom(sm => sm.DateAndTime.ToString(SeminarConstraints.DateAndTimeFormat, CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Category, s =>
                    s.MapFrom(sm => sm.Category.Name))
                .ForMember(dest => dest.Organizer, src => 
                    src.MapFrom(dest => dest.Organizer.UserName));

            CreateMap<EditSeminarViewModel, Seminar>()
                .ForMember(dest => dest.DateAndTime, opt =>
                    opt.MapFrom(m => DateTime.ParseExact(m.DateAndTime, SeminarConstraints.DateAndTimeFormat,
                        CultureInfo.InvariantCulture, DateTimeStyles.None)))
                .ForMember(dest => dest.OrganizerId, src =>
                    src.MapFrom(s => s.OrganizerId));

            CreateMap<Seminar, DeleteSeminarViewModel>()
                .ForMember(dest => dest.Organizer, src =>
                    src.MapFrom(s => s.OrganizerId));
        } 
    }
}
