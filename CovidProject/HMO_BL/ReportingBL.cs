using HMO_API.models;
using HMO_COMMON;
using HMO_DAL1;
using System.Collections.Generic;

namespace HMO_BL
{
    public class ReportingBL
    {
        MembersRepository membersRepository;
        public ReportingBL()
        {
            membersRepository = new MembersRepository();

        }
        public async Task<List<HMO_DTO.models.Member>> GetMembers()
        {

            List<HMO_DTO.models.Member> members = new List<HMO_DTO.models.Member>();
            try
            {
                var repositoryMembersList = await membersRepository.GetMembers();
                foreach (Member member in repositoryMembersList)
                {
                    members.Add
                        (AutoMapperManager.InitializeAutoMapper().Map<HMO_DTO.models.Member>(member));

                }
                return members;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<HMO_DTO.models.Member> GetMemberByTZ(string tz)
        {

            HMO_DTO.models.Member member = new HMO_DTO.models.Member();
            try
            {
                var repositoryMembers = await membersRepository.GetMemberByTZ(tz);

                member = AutoMapperManager.InitializeAutoMapper().Map<HMO_DTO.models.Member>(repositoryMembers);

                List<HMO_DTO.models.MedicalEvent> eventList = await membersRepository.GetMemberEventsByID(member.Id);
                member.MedicalEvents = eventList;
                return member;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<HMO_DTO.models.Member> GetMemberByID(long Id)
        {

            HMO_DTO.models.Member member = new HMO_DTO.models.Member();
            try
            {
                var repositoryMembers = await membersRepository.GetMemberByID(Id);

                member = AutoMapperManager.InitializeAutoMapper().Map<HMO_DTO.models.Member>(repositoryMembers);

                List<HMO_DTO.models.MedicalEvent> eventList = await membersRepository.GetMemberEventsByID(member.Id);
                member.MedicalEvents = eventList;
                return member;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}