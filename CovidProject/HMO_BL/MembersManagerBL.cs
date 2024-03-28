using HMO_API.models;
using HMO_COMMON;
using HMO_DAL1;
using System.Collections.Generic;

namespace HMO_BL
{
    public class MembersMnagerBL
    {
        MembersRepository membersRepository;
        MemberEventsValidator memberEventsValidator;
        MedicalEventValidator medicalEventValidator;
        public MembersMnagerBL()
        {
            membersRepository = new MembersRepository();
            memberEventsValidator=new MemberEventsValidator();
            medicalEventValidator=new MedicalEventValidator();

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
        public async Task<int> AddMember(HMO_DTO.models.Member member)
        {
            Member repositoryMember = new Member();
            int result = 0;
            try
            {
                if (member != null)
                {
                    repositoryMember = AutoMapperManager.InitializeAutoMapper().Map<HMO_API.models.Member>(member);
                    result = await membersRepository.AddMember(repositoryMember);
                    if (result == 0)
                    {
                        throw new ApplicationException("Member failed creation - please contact the support");
                    }

                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<int> AddMedicalEvent(HMO_DTO.models.MedicalEvent medicalEvent)
        {
            MedicalEvent repositoryMedicalEvent = new MedicalEvent();
            int result = 0;
            try
            {
                if (medicalEvent != null && medicalEventValidator.Validate(medicalEvent))
                {
                    repositoryMedicalEvent = AutoMapperManager.InitializeAutoMapper().Map<HMO_API.models.MedicalEvent>(medicalEvent);
                    result = await membersRepository.AddMedicalEvent(repositoryMedicalEvent);
                    if (result == 0)
                    {
                        throw new ApplicationException("MedicalEvent failed creation - please contact the support");
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<int> UpdateMember(HMO_DTO.models.Member member)
        {
            Member repositoryMember = new Member();
            int result = 0;

            try
            {
                if (member != null)
                {
                    repositoryMember = AutoMapperManager.InitializeAutoMapper().Map<HMO_API.models.Member>(member);

                    result = await membersRepository.UpdateMember(repositoryMember);
                    if (result == 0)
                    {
                        throw new ApplicationException("Member failed updation - please contact the support");
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<int> DeleteMember(string tz)
        {
            int result = 0;

            try
            {
                if (tz != null)
                {


                    result = await membersRepository.DeleteMember(tz);
                    if (result == 0)
                    {
                        throw new ApplicationException("Member failed deletion - please contact the support");
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<int> AddVaccinEvent(HMO_DTO.models.MedicalEvent medicalEvent)
        {
            VaccinEvent repositoryVaccinEvent = new VaccinEvent();
            MedicalEvent repositoryMedicalEvent = new MedicalEvent();

            int resultId = 0;

            try
            {
                if (medicalEvent != null&& medicalEventValidator.Validate(medicalEvent) &&  memberEventsValidator.ValidateVaccineEvent(medicalEvent, membersRepository.GetMemberEventsByID(medicalEvent.MemberID).Result.ToList())
)
                {
                    repositoryVaccinEvent = AutoMapperManager.InitializeAutoMapper().Map<HMO_API.models.VaccinEvent>(medicalEvent);
                    repositoryVaccinEvent.Vaccine = null;
                    repositoryMedicalEvent = AutoMapperManager.InitializeAutoMapper().Map<HMO_API.models.MedicalEvent>(medicalEvent);

                    resultId = await membersRepository.AddVaccinEvent(repositoryVaccinEvent);
                    if (resultId == 0)
                    {
                        throw new ApplicationException("VaccinEvent failed creation - please contact the support");
                    }
                    repositoryMedicalEvent.EventExtensionId = resultId;
                    resultId = await membersRepository.AddMedicalEvent(repositoryMedicalEvent);

                }
                return resultId;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}