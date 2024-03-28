using HMO_DTO;

namespace HMO_COMMON
{
    public class MemberEventsValidator
    {
        public bool ValidateVaccineEvent(HMO_DTO.models.MedicalEvent medicalEvent, List<HMO_DTO.models.MedicalEvent> events)
        {
            bool validated = true;
            int counter = 0;
            foreach (HMO_DTO.models.MedicalEvent e in events)
            {
                if (e.EventTypeId==4)
                { 
                    counter++;
                }

            }
            if(counter >=4)
            {
                 validated=false;

            }
            else
            {
                validated = true;
            }
            return validated;

        }
        public bool ValidateMedicalEvent(HMO_DTO.models.MedicalEvent medicalEvent, List<HMO_DTO.models.MedicalEvent> events)
        {
            bool validated = true;
            int counter = 0;
            foreach (HMO_DTO.models.MedicalEvent e in events)
            {
                if (e.EventTypeId == medicalEvent.EventTypeId)
                {
                    counter++;
                }

            }
            if (counter >= 4)
            {
                validated = false;

            }
            else
            {
                validated = true;
            }
            return validated;

        }
    }
}