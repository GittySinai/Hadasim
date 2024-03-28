export class MedicalEvent {
    eventDate: Date
    comments?: string;
    eventName?: string;
    vaccineName?: string;
    bodyLocation?: string;
    vaccineCost?: number;
    eventTypeId: number;
    memberID: number;
    vaccineId?: number;

    constructor(
        eventDate: Date,
        eventTypeId: number,
        memberID: number,
        vaccineId: number,
        comments?: string,
        eventName?: string,
        vaccineName?: string,
        bodyLocation?: string,
        vaccineCost?: number,
    ) {
        this.eventDate = eventDate;
        this.comments = comments;
        this.eventName = eventName;
        this.vaccineName = vaccineName;
        this.bodyLocation = bodyLocation;
        this.vaccineCost = vaccineCost;
        this.eventTypeId = eventTypeId;
        this.memberID = memberID;
        this.vaccineId = vaccineId;
    }
}
export class VaccineTypeEnum {
    static options = [
      { id: 1, name: "COVID-19 Pfizer" },
      { id: 5, name: "COVID-19 Novavax" },
      { id: 8, name: "COVID-19 AstraZeneca" },
      { id: 13, name: "COVID-19 Johnson & Johnson" },
      { id: 14, name: "COVID-19 Sinovac" }
    ];
    static namesOptions = [
        "COVID-19 Pfizer" ,
        "COVID-19 Novavax" ,
        "COVID-19 AstraZeneca" ,
        "COVID-19 Johnson & Johnson" ,
         "COVID-19 Sinovac" 
      ];
      static getIdByName(name: string): number {
        console.log("Searching for name:", name);
        const option = VaccineTypeEnum.options.find(option => option.name === name);
        console.log("Found option:", option);
        return option ? option.id : -1;}
  }

  
  export class EventTypeEnum {
    static getOptionById() {
      throw new Error('Method not implemented.');
    }
    static options = [
      { id: 1, name: "Disease diagnosis" },
      { id: 2, name: "Recovery" },
      { id: 3, name: "Receive a positive result" },
      { id: 4, name: "Vaccination" }
    ];
    static namesOptions = [
        "Disease diagnosis" ,
        "Recovery" ,
        "Receive a positive result" 
      ];
    static getIdByName(name: string): number {
        const option = EventTypeEnum.options.find(option => option.name === name);
        return option ? option.id : -1; // Return -1 if the name is not found
      }
  }