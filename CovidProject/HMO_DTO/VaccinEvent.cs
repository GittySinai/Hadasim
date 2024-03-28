using System;
using System.Collections.Generic;

namespace HMO_DTO.models;

public partial class VaccinEvent
{
    public int Id { get; set; }

    public int VaccineId { get; set; }

    public long MemberId { get; set; }

    public string BodyLocation { get; set; } = null!;

   // public virtual ICollection<MedicalEvent> MedicalEvents { get; set; } = new List<MedicalEvent>();

   // public virtual Member Member { get; set; } = null!;

    //public virtual VaccineType Vaccine { get; set; } = null!;
}
