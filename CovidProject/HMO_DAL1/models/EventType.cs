using System;
using System.Collections.Generic;

namespace HMO_API.models;

public partial class EventType
{
    public int Id { get; set; }

    public string EventTypeName { get; set; } = null!;

    public virtual ICollection<MedicalEvent> MedicalEvents { get; set; } = new List<MedicalEvent>();
}
