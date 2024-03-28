using HMO_DTO.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_COMMON
{
    public class MedicalEventValidator
    {
        public MedicalEventValidator() { }

        public bool Validate(MedicalEvent medicalEvent)
        {
            bool validated = true;
            if (medicalEvent.EventDate > DateTime.Today)
                validated = false;
            return validated;

        }

    }
}
