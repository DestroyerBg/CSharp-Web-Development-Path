using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SeminarHub.AutoMappers;
using SeminarHub.Data;
using SeminarHub.Data.DatabaseModels;
using SeminarHub.Extensions;
using SeminarHub.Models.ViewModels;

namespace SeminarHub.Services
{
    public class SeminarService
    {
        private readonly SeminarHubDbContext context;
        private readonly IMapper mapper;
        public SeminarService(SeminarHubDbContext _context,
            IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<AddSeminarViewModel> CreateBlackSeminarModel(IdentityUser user)
        {
            AddSeminarViewModel model = new AddSeminarViewModel();
            model.OrganizerId = user.Id;
            return model;
        }

        public async Task<bool> AddSeminar(AddSeminarViewModel model)
        {
            Seminar seminar = mapper.Map<Seminar>(model);

            await context.Seminars.AddAsync(seminar);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<AllSeminarsViewModel>> LoadSeminarsFromDatabaseAsync()
        {
            ICollection<AllSeminarsViewModel> seminarModels = context.Seminars
                .Include(s => s.Category)
                .Include(s => s.Organizer)
                .OrderByDescending(s => s.Topic)
                .Select(s => mapper.Map<Seminar, AllSeminarsViewModel>(s))
                .ToList();

            return seminarModels;
        }

        public async Task<SeminarDetailsViewModel> LoadDetailsForSeminar(int id)
        {
            Seminar seminar = await context.Seminars
                .Include(s => s.Category)
                .Include(s => s.Organizer)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (seminar == null)
            {
                return null;
            }

            SeminarDetailsViewModel model = mapper.Map<Seminar, SeminarDetailsViewModel>(seminar);

            return model;
        }

        public async Task<EditSeminarViewModel> CreateSeminarEditModel(int id)
        {
           Seminar seminar = await context.Seminars
                .Include(s => s.Category)
                .Include(s => s.Organizer)
                .FirstOrDefaultAsync(s => s.Id == id);

           if (seminar == null)
           {
               return null;
           }

           EditSeminarViewModel model = mapper.Map<Seminar, EditSeminarViewModel>(seminar);
           return model;
        }

        public async Task<bool> EditSeminar(EditSeminarViewModel model)
        {
            Seminar seminar = await context.Seminars
                .Include(s => s.Category)
                .Include(s => s.Organizer)
                .FirstOrDefaultAsync(s => s.Id == model.Id);

            if (seminar == null)
            {
                return false;
            }

            mapper.Map(model, seminar);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<DeleteSeminarViewModel> CreateDeleteSeminarViewModel(int id)
        {
            Seminar? seminar = await context.Seminars
                .Include(s => s.Category)
                .Include(s => s.Organizer)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (seminar == null)
            {
                return null;
            }

            DeleteSeminarViewModel model = mapper.Map<Seminar, DeleteSeminarViewModel>(seminar);

            return model;
        }

        public async Task<bool> DeleteSeminar(DeleteSeminarViewModel model)
        {
            Seminar? seminar = await
                context.Seminars
                    .FirstOrDefaultAsync(s => s.Id == model.Id);

            if (seminar == null)
            {
                return false;
            }

            ICollection<SeminarParticipant> seminarParticipants = await context.SeminarsParticipants
                .Where(sp => sp.SeminarId == seminar.Id)
                .ToListAsync();

            
            context.SeminarsParticipants.RemoveRange(seminarParticipants);
            context.Seminars.Remove(seminar);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<AllSeminarsViewModel>> GetJoinedSeminars(IdentityUser user)
        {
            ICollection<AllSeminarsViewModel> seminars = await context.Seminars
                .Include(s => s.SeminarsParticipants)
                .Include(s => s.Organizer)
                .Include(s => s.Category)
                .Where(s => s.SeminarsParticipants.Any(p => p.ParticipantId == user.Id))
                .OrderByDescending(s => s.Topic)
                .Select(s => mapper.Map<Seminar, AllSeminarsViewModel>(s))
                .ToListAsync();

            return seminars;
        }

        public async Task<bool> JoinToSeminar(int id, IdentityUser user)
        {
            Seminar? seminar = await context.Seminars
                .Include(s => s.Category)
                .Include(s => s.Organizer)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (seminar == null)
            {
                return false;
            }

            bool isAlreadyJoined = await context.SeminarsParticipants
                .AnyAsync(s => s.ParticipantId == user.Id && s.SeminarId == seminar.Id);

            if (isAlreadyJoined)
            {
                return false;
            }

            SeminarParticipant seminarParticipant = new SeminarParticipant()
            {
                ParticipantId = user.Id,
                SeminarId = seminar.Id
            };


            await context.SeminarsParticipants.AddAsync(seminarParticipant);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> LeaveSeminar(int id, IdentityUser user)
        {
            Seminar? seminar = await context.Seminars
                .Include(s => s.Category)
                .Include(s => s.Organizer)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (seminar == null)
            {
                return false;
            }

            bool isAlreadyHere = await context.SeminarsParticipants
                .AnyAsync(s => s.ParticipantId == user.Id && s.SeminarId == seminar.Id);

            if (!isAlreadyHere)
            {
                return false;
            }

            SeminarParticipant seminarParticipant = new SeminarParticipant()
            {
                ParticipantId = user.Id,
                SeminarId = seminar.Id
            };


            context.SeminarsParticipants.Remove(seminarParticipant);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
