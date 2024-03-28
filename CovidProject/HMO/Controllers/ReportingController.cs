//using HMO_BL;
//using HMO_DAL1;
//using HMO_DTO.models;
//using Microsoft.AspNetCore.Mvc;


//namespace HMO_API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MembersController : ControllerBase
//    {
//        MembersMnagerBL membersMnagerBL;
//        public MembersController()
//        {
//            membersMnagerBL = new MembersMnagerBL();
//        }
//        [HttpGet("GetMembers")]
//        public async Task<List<Member>> GetMembers()
//        {
//            try
//            {
//                var members = await membersMnagerBL.GetMembers();
//                return members;
//            }
//            catch (Exception ex)
//            {
//                return new List<Member>();
//            }

//        }

//        [HttpGet("GetMemberByTZ/{tz}")]
//        public async Task<Member> GetMemberByTZ(string tz)
//        {
//            try
//            {
//                var member = await membersMnagerBL.GetMemberByTZ(tz);
//                return member;
//            }
//            catch (Exception ex)
//            {
//                return new Member();
//            }

//        }
//        [HttpPost("AddMember")]
//        public async Task<int> AddMember([FromBody] Member member)
//        {
//            try
//            {
//                int res = await membersMnagerBL.AddMember(member);
//                return res;
//            }
//            catch
//            {
//                return 0;
//            }

//        }
//        [HttpPost("AddMedicalEvent")]
//        public async Task<int> AddMedicalEvent([FromBody] MedicalEvent medicalEvent)
//        {
//            try
//            {
//                int res = await membersMnagerBL.AddMedicalEvent(medicalEvent);
//                return res;
//            }
//            catch
//            {
//                return 0;
//            }

//        }
//        [HttpPost("AddVaccinEvent")]
//        public async Task<int> AddVaccinEvent([FromBody] MedicalEvent medicalEvent)
//        {
//            try
//            {
//                int res = await membersMnagerBL.AddVaccinEvent( medicalEvent);
//                return res;
//            }
//            catch
//            {
//                return 0;
//            }

//        }

//        [HttpPut("UpdateMember")]
//        public async Task<int> UpdateMember([FromBody] Member member)
//        {
//            try
//            {
//                int res = await membersMnagerBL.UpdateMember(member);
//                return res;
//            }
//            catch
//            {
//                return 0;
//            }
//        }

//        // DELETE api/<MembersController>/5
//        [HttpDelete("DeleteMember/{tz}")]
//        public async Task<int> DeleteMember(string tz)
//        {
//            try
//            {
//                int res = await membersMnagerBL.DeleteMember(tz);
//                return res;
//            }
//            catch
//            {
//                return 0;
//            }
//        }
//    }
//}
