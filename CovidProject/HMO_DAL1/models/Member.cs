using System;
using System.Collections.Generic;

namespace HMO_API.models;

public partial class Member
{
    public long Id { get; set; }

    public string Tz { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string HouseNumber { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string Mobile { get; set; } = null!;

    public virtual ICollection<MedicalEvent> MedicalEvents { get; set; } = new List<MedicalEvent>();

    public virtual ICollection<VaccinEvent> VaccinEvents { get; set; } = new List<VaccinEvent>();
}
