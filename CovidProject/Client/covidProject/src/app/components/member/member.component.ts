import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EventTypeEnum, MedicalEvent, VaccineTypeEnum } from 'src/app/models/medicalEvents';
import { Member } from 'src/app/models/memberModel';
import { MembersService } from 'src/app/services/members.service';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.scss']
})
export class MemberComponent implements OnInit {

  constructor(private membersService: MembersService, private formBuilder: FormBuilder) { }

  showDetails: boolean = false;
  @Input() member!: Member;
  memberDataUpdate!: Member;
  showForm: boolean = false;
  showEventForm: boolean = false;
  memberForm!: FormGroup;
  eventForm!: FormGroup;
  showVaccineForm: boolean = false;
  vaccineForm!: FormGroup;

  eventTypeOptions = EventTypeEnum.namesOptions; // Define eventTypeOptions with EventTypeEnum options
  newEvent: MedicalEvent = new MedicalEvent(new Date(), 0, 0, 0); // Initialize newEvent with default values

  vaccineTypeOptions = VaccineTypeEnum.namesOptions; // Define eventTypeOptions with EventTypeEnum options
  newVaccine: MedicalEvent = new MedicalEvent(new Date(), 0, 0, 0, "", "", "", "", 0); // Initialize newEvent with default values
  vaccineEventsCount: number = 0
  showAddVaccin: boolean = true


  ngOnInit() {

  }
  countVaccineEventsForMember() {
    debugger
    this.vaccineEventsCount = 0; // Reset count before counting again
    if (this.member.medicalEvents) {
      for (const event of this.member.medicalEvents) {
        if (event.eventTypeId === 4) { // Assuming vaccine event type ID is 4
          this.vaccineEventsCount++;
        }
      }
    }
    if (this.vaccineEventsCount >= 4) {
      this.showAddVaccin = false;
    } else {
      this.showAddVaccin = true;
    }
  }


  closeMemberDetails() {
    this.showDetails = false;
  }
  showMemberDetails() {
    this.showDetails = true;
    this.getMemberByTZ();
  }
  getMemberByTZ() {
    this.membersService.getMemberByTZ(this.member.tz).subscribe({
      next: (res) => {
        this.member = res;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }
  deleteMember() {
    this.membersService.deleteMember(this.member.tz).subscribe({
      next: (res) => {
        console.log(res);
        window.location.reload();

      },
      error: (error) => {
        console.log(error);
      }
    });
  }
  //Update member
  updateMember() {
    this.showForm = true;
    this.buildForm(this.member);
  }
  buildForm(member: Member) {
    this.memberForm = this.formBuilder.group({
      firstName: [member.firstName, [Validators.required, Validators.pattern('[a-zA-Z ]{3,}')]],
      lastName: [member.lastName, [Validators.required, Validators.pattern('[a-zA-Z ]{3,}')]],
      birthDate: [this.formatDate(member.birthDate), Validators.required],
      city: [member.city, Validators.required],
      street: [member.street, Validators.required],
      houseNumber: [member.houseNumber, Validators.required],
      phoneNumber: [member.phoneNumber, Validators.required],
      mobile: [member.mobile, Validators.required],
    });
  }
  formatDate(date: any): string {
    // Ensure that the date is in the correct format
    return date ? new Date(date).toISOString().substring(0, 10) : '';
  }
  isFieldMemberInvalid(field: string) {
    const control = this.memberForm.get(field);
    return control?.invalid && (control?.dirty || control?.touched);
  }
  submitForm() {
    if (this.memberForm.invalid) {
      return;
    }

    this.member = { ...this.member, ...this.memberForm.value };

    this.membersService.updateMember(this.member).subscribe({
      next: (res) => {
        console.log(res);
        this.showForm = false;
        window.location.reload();
      },
      error: (error) => {
        console.log(error);
      }
    });


  }
  cancel() {
    this.showForm = false;
  }

  //Add event
  isFieldInvalid(field: string) {
    const control = this.eventForm.get(field);
    return control?.invalid && (control?.dirty || control?.touched);
  }
  addEvent() {
    this.showEventForm = true;
    this.buildEventForm();
  }
  buildEventForm() {
    this.eventForm = this.formBuilder.group({
      eventName: [this.eventTypeOptions[0]],
      eventDate: ['', Validators.required],
      comments: [''],

    });
  }
  submitEventForm() {
    console.log(this.eventForm.controls['eventName'].value)

    if (this.eventForm.invalid) {
      return;
    }
    if (this.eventForm.controls['comments'].value) {
      this.newEvent.comments = this.eventForm.controls['comments'].value;

    }
    this.newEvent.eventDate = this.eventForm.controls['eventDate'].value;
    this.newEvent.eventTypeId = EventTypeEnum.getIdByName(this.eventForm.controls['eventName'].value);
    this.newEvent.memberID = this.member.id

    this.membersService.addMedicalEvent(this.newEvent).subscribe({
      next: (res) => {
        console.log(res);
        this.showEventForm = false;

        window.location.reload();
      },
      error: (error) => {
        console.log(error);
      }
    });


  }
  closeDialog() {
    this.showAddVaccin = true
  }
  cancelAddEvent() {
    this.showEventForm = false;
  }

  //Add vaccine

  isFieldInvalidVaccineForm(field: string) {
    const control = this.vaccineForm.get(field);
    return control?.invalid && (control?.dirty || control?.touched);
  }
  addVaccine() {
    debugger
    this.countVaccineEventsForMember()
    if (this.showAddVaccin) {
      this.showVaccineForm = true;
      this.buildVaccineForm();
    }


  }
  buildVaccineForm() {

    this.vaccineForm = this.formBuilder.group({
      eventDate: ['', Validators.required],
      comments: [''],
      vaccineName: [this.vaccineTypeOptions[0]],
      bodyLocation: ['', Validators.required],
    });

  }
  submitVaccineForm() {

    if (this.vaccineForm.invalid) {
      return;
    }
    if (this.vaccineForm.controls['comments'].value) {
      this.newVaccine.comments = this.vaccineForm.controls['comments'].value;
    }
    this.newVaccine.eventDate = this.vaccineForm.controls['eventDate'].value;
    this.newVaccine.vaccineId = VaccineTypeEnum.getIdByName(this.vaccineForm.controls['vaccineName'].value);
    this.newVaccine.memberID = this.member.id
    this.newVaccine.eventName = "Vaccination"
    this.newVaccine.eventTypeId = 4
    this.newVaccine.bodyLocation = this.vaccineForm.controls['bodyLocation'].value;




    this.membersService.addVaccinEvent(this.newVaccine).subscribe({
      next: (res) => {
        console.log(res);
        window.location.reload();
        this.showVaccineForm = false;


      },
      error: (error) => {
        console.log(error);
      }
    });

  }
  cancelAddVaccine() {
    this.showVaccineForm = false;
  }
}
