import { MedicalEvent } from "./medicalEvents";



export class Member {
    id: number;
    tz: string;
    firstName: string;
    lastName: string;
    birthDate: Date;
    city: string;
    street: string;
    houseNumber: string;
    phoneNumber: string;
    mobile: string;
    medicalEvents?: MedicalEvent[]; 
  
    constructor(
      id: number,
      tz: string,
      firstName: string,
      lastName: string,
      birthDate: Date,
      city: string,
      street: string,
      houseNumber: string,
      phoneNumber: string,
      mobile: string,
      medicalEvents?: MedicalEvent[] 
    ) {
      this.id = id;
      this.tz = tz;
      this.firstName = firstName;
      this.lastName = lastName;
      this.birthDate = birthDate;
      this.city = city;
      this.street = street;
      this.houseNumber = houseNumber;
      this.phoneNumber = phoneNumber;
      this.mobile = mobile;
      this.medicalEvents = medicalEvents; 
    }
  }

  