using System;
using System.Collections.Generic;

namespace HMO_DTO.models;

public partial class MedicalEvent
{
    public int Id { get; set; }
    public DateTime EventDate { get; set; }
    public string? Comments { get; set; }
    public string? EventName { get; set; }
    public string? VaccineName { get; set; }      
    public string? BodyLocation { get; set; }
    public decimal? VaccineCost { get; set; }
    public int EventTypeId { get; set; }
    public int  MemberID { get; set; }
    public int? VaccineId { get; set; }

}
