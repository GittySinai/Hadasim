using HMO_API.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HMO_DAL1
{
    public class EventsRepository
    {

        HmoContext context;

        public EventsRepository()
        {
            context = new HmoContext();
        }
        public async Task<List<MedicalEvent>> GetAllEvents()
        {
            List<MedicalEvent> events = new List<MedicalEvent>();
            try
            {
                events = await context.MedicalEvents.ToListAsync();
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
                vaccineTypes = await context.VaccineTypes.ToListAsync();
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
                eventTypes = await context.EventTypes.ToListAsync();
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
                vaccinEvents = await context.VaccinEvents.ToListAsync();
                return vaccinEvents;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}