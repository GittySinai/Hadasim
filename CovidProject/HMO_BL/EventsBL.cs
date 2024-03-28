using HMO_API.models;
using HMO_COMMON;
using HMO_DAL1;
using System.Collections.Generic;

namespace HMO_BL
{
    public class EventsBL
    {
        EventsRepository eventsRepository;
        public EventsBL()
        {
            eventsRepository = new EventsRepository();

        }



        public async Task<List<MedicalEvent>> GetAllEvents()
        {
            List<MedicalEvent> events = new List<MedicalEvent>();
            try
            {
                events = await eventsRepository.GetAllEvents();
                return events;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<VaccineType>> GetVaccineTypes()
        {
            List<VaccineType> vaccineTypes = new List<VaccineType>();
            try
            {
                vaccineTypes = await eventsRepository.GetVaccineTypes();
                return vaccineTypes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<EventType>> GetEventTypes()
        {
            List<EventType> eventTypes = new List<EventType>();
            try
            {
                eventTypes = await eventsRepository.GetEventTypes();
                return eventTypes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<VaccinEvent>> GetVaccinEvents()
        {
            List<VaccinEvent> vaccinEvents = new List<VaccinEvent>();
            try
            {
                vaccinEvents = await eventsRepository.GetVaccinEvents();
                return vaccinEvents;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}