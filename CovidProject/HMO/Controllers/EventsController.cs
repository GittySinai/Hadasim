//using HMO_API.models;
//using HMO_BL;
//using Microsoft.AspNetCore.Mvc;


//namespace HMO_API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EventsController : ControllerBase
//    {
//        EventsBL eventsBL;
//        public EventsController()
//        {
//            eventsBL = new EventsBL();
//        }
//        [HttpGet("GetAllEvents")]

//        public async Task<List<MedicalEvent>> GetAllEvents()
//        {
//            List<MedicalEvent> events = new List<MedicalEvent>();
//            try
//            {
//                events = await eventsBL.GetAllEvents();
//                return events;
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }
//        [HttpGet("GetVaccineTypes")]

//        public async Task<List<VaccineType>> GetVaccineTypes()
//        {
//            List<VaccineType> vaccineTypes = new List<VaccineType>();
//            try
//            {
//                vaccineTypes = await eventsBL.GetVaccineTypes();
//                return vaccineTypes;
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }
//        [HttpGet("GetEventTypes")]

//        public async Task<List<EventType>> GetEventTypes()
//        {
//            List<EventType> eventTypes = new List<EventType>();
//            try
//            {
//                eventTypes = await eventsBL.GetEventTypes();
//                return eventTypes;
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }
//        [HttpGet("GetVaccinEvents")]

//        public async Task<List<VaccinEvent>> GetVaccinEvents()
//        {
//            List<VaccinEvent> vaccinEvents = new List<VaccinEvent>();
//            try
//            {
//                vaccinEvents = await eventsBL.GetVaccinEvents();
//                return vaccinEvents;
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }



//    }
//}
