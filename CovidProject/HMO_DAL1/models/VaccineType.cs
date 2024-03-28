using System;
using System.Collections.Generic;

namespace HMO_API.models;

public partial class VaccineType
{
    public int Id { get; set; }

    public string VaccineName { get; set; } = null!;

    public decimal Cost { get; set; }

    public string Manufacturer { get; set; } = null!;

    public virtual ICollection<VaccinEvent> VaccinEvents { get; set; } = new List<VaccinEvent>();
}
