using HMO_API.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HMO_DAL1
{
    public class ReportingRepository
    {

        HmoContext context;

        public ReportingRepository()
        {
            context = new HmoContext();
        }
        public async Task<List<Member>> GetMembers()
        {
            List<Member> members = new List<Member>();
            try
            {
                members = await context.Members.ToListAsync();
                return members;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Member> GetMemberByTZ(string tz)
        {
            Member member = new Member();
            try
            {
                member = await context.Members
                    .Include(member => member.MedicalEvents)
                    .ThenInclude(medicalEvent => medicalEvent.EventExtension)
                    .Where(member => member.Tz.Equals(tz))
                    .FirstOrDefaultAsync();




                return member;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<HMO_DTO.models.MedicalEvent>> GetMemberEventsByID(long Id)
        {
            List<HMO_DTO.models.MedicalEvent> eventList = new List<HMO_DTO.models.MedicalEvent>();
            try
            {
                eventList = await (from medicalEvent in context.MedicalEvents
                                        join eventType in context.EventTypes on medicalEvent.EventTypeId equals eventType.Id
                                        join vaccinEvent in context.VaccinEvents on medicalEvent.EventExtensionId equals vaccinEvent.Id
                                        into memberEvents1
                                        from info1 in memberEvents1.DefaultIfEmpty()
                                        join vaccinType in context.VaccineTypes on info1.VaccineId equals vaccinType.Id
                                        into memberEvents
                                        from info in memberEvents.DefaultIfEmpty()

                                        where medicalEvent.MemberId == Id
                                        select new HMO_DTO.models.MedicalEvent
                                        {
                                            EventName = eventType.EventTypeName,
                                            EventDate = medicalEvent.EventDate,
                                            Comments = medicalEvent.Comments,
                                            VaccineName = info.VaccineName ?? "",
                                            BodyLocation = info1.BodyLocation??"",
                                            VaccineCost = info.Cost,
                                            EventTypeId= eventType.Id

                                        }).ToListAsync();

                return eventList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AddMember(Member member)
        {
            try
            {
                context.Members.Add(member);
                var created = await context.SaveChangesAsync();

                return created;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AddMedicalEvent(MedicalEvent medicalEvent)
        {
            try
            {
                context.MedicalEvents.Add(medicalEvent);
                var created = await context.SaveChangesAsync();

                return created;
            }
            catch (Exception ex)
            {
                throw;
            }


        }
        public async Task<int> AddVaccinEvent(VaccinEvent vaccinEvent)
        {
            try
            {
                context.VaccinEvents.Add(vaccinEvent);
                var created = await context.SaveChangesAsync();

                return vaccinEvent.Id;
            }
            catch (Exception ex)
            {
                throw;
            }


        }
        public async Task<int> UpdateMember(Member member)
        {
            {
                try
                {
                    context.Members.Update(member);
                    var uptated = await context.SaveChangesAsync();

                    return uptated;
                }
                catch (Exception ex)
                {
                    throw;
                }


            }
        }
        public async Task<int> DeleteMember(string tz)
        {
            try
            {
                var memberToDelete = await context.Members.FirstOrDefaultAsync(m => m.Tz == tz);
                if (memberToDelete != null)
                {
                    context.Members.Remove(memberToDelete);
                    var deleted = await context.SaveChangesAsync();
                    return deleted;

                }

                return 0;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public async Task<Member> GetMemberByID(long id)
        {
            Member member = new Member();
            try
            {
                member = await context.Members
                    .Include(member => member.MedicalEvents)
                    .ThenInclude(medicalEvent => medicalEvent.EventExtension)
                    .Where(member => member.Id.Equals(id))
                    .FirstOrDefaultAsync();

                return member;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
      
    }
}