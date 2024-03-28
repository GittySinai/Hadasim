using System;
using System.Collections.Generic;

namespace HMO_API.models;

public partial class MedicalEvent
{
    public int Id { get; set; }

    public int EventTypeId { get; set; }

    public long MemberId { get; set; }

    public DateTime EventDate { get; set; }

    public string? Comments { get; set; }

    public int? EventExtensionId { get; set; }

    public virtual VaccinEvent? EventExtension { get; set; }

    public virtual EventType EventType { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
