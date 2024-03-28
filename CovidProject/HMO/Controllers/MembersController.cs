using HMO_BL;
using HMO_DAL1;
using HMO_DTO.models;
using Microsoft.AspNetCore.Mvc;


namespace HMO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        MembersMnagerBL membersMnagerBL;
        public MembersController()
        {
            membersMnagerBL = new MembersMnagerBL();
        }
        [HttpGet("GetMembers")]
        public async Task<ActionResult<List<Member>>> GetMembers()
        {
            try
            {
                var members = await membersMnagerBL.GetMembers();
                return members;
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return BadRequest("General error, please contact support"); ;
            }

        }

        [HttpGet("GetMemberByTZ/{tz}")]
        public async Task<Member> GetMemberByTZ(string tz)
        {
            try
            {
                var member = await membersMnagerBL.GetMemberByTZ(tz);
                return member;
            }
            catch (Exception ex)
            {
                return new Member();
            }

        }
        [HttpPost("AddMember")]
        public async Task<ActionResult<int>> AddMember([FromBody] Member member)
        {
            try
            {
                int res = await membersMnagerBL.AddMember(member);
                return Ok(res);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return BadRequest("General error, please contact support"); ;
            }
        }

        [HttpPost("AddMedicalEvent")]
        public async Task<ActionResult<int>> AddMedicalEvent([FromBody] MedicalEvent medicalEvent)
        {
            try
            {

                int res = await membersMnagerBL.AddMedicalEvent(medicalEvent);

                return Ok(res);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return BadRequest("General error, please contact support"); ;
            }
        }

        [HttpPost("AddVaccinEvent")]
        public async Task<ActionResult<int>> AddVaccinEvent([FromBody] MedicalEvent medicalEvent)
        {
            try
            {
                int res = await membersMnagerBL.AddVaccinEvent(medicalEvent);
                return Ok(res);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return BadRequest("General error, please contact support"); ;
            }
        }

        [HttpPut("UpdateMember")]
        public async Task<ActionResult<int>> UpdateMember([FromBody] Member member)
        {
            try
            {
                int res = await membersMnagerBL.UpdateMember(member);
                return Ok(res);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return BadRequest("General error, please contact support"); ;
            }
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("DeleteMember/{tz}")]
        public async Task<ActionResult<int>> DeleteMember(string tz)
        {
            try
            {
                int res = await membersMnagerBL.DeleteMember(tz);
                return Ok(res);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return BadRequest("General error, please contact support"); ;
            }
        }
    }
}
