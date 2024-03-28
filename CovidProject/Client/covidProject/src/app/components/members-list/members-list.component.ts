import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Member } from 'src/app/models/memberModel';
import { MembersService } from 'src/app/services/members.service';

@Component({
  selector: 'app-members-list',
  templateUrl: './members-list.component.html',
  styleUrls: ['./members-list.component.scss']
})
export class MembersListComponent {
  constructor(private membersService:MembersService,private formBuilder: FormBuilder) { }
  membersList: Member[] = []
  memberForm!: FormGroup; 
showForm:boolean=false;
selectedMember!: Member  
showDetails:boolean=false
ngOnInit(){
this.getMembers()

}

getMembers(){
  this.membersService.getMembers().subscribe({
    next: (res) => {
      this.membersList=res
    },
    error: (error) => {
      console.log(error);
    }
  });
 
}
addMember(){
  this.showForm =true
  this.buildForm()
}
buildForm(){
  this.memberForm = this.formBuilder.group({
    tz: ['', [Validators.required, Validators.pattern('[0-9]{9}')]],
    firstName: ['', [Validators.required, Validators.pattern('[a-zA-Z ]{3,}')]],
    lastName: ['', [Validators.required, Validators.pattern('[a-zA-Z ]{3,}')]],
    birthDate: ['', Validators.required],
    city: ['', Validators.required],
    street: ['', Validators.required],
    houseNumber: ['', Validators.required],
    phoneNumber: ['', Validators.required],
    mobile: ['', Validators.required],
  });
}
//   membersList: Member[] = [
//     new Member(1,'123456789','John','Doe',new Date('1990-01-01'),'New York','Main Street','123','555-1234','555-5678',
//       [{id: 1,eventTypeId: 1,memberId: 1,eventDate: new Date('2023-05-10T08:00:00Z'),comments: 'Annual checkup',eventExtensionId: 1,
//       eventExtension: {id: 1,vaccineId: 1,memberId: 1,bodyLocation: 'Left arm' }}]),
//     new Member(2, '987654321', 'Jane', 'Smith', new Date('1985-02-15'), 'Los Angeles', 'Oak Avenue', '456', '555-4321', '555-8765'),
//     new Member(3, '456123789', 'Alice', 'Johnson', new Date('1988-07-20'), 'Chicago', 'Elm Street', '789', '555-7890', '555-2345'),
//     new Member(4, '789456123', 'Bob', 'Williams', new Date('1992-04-10'), 'Houston', 'Cedar Lane', '1011', '555-6789', '555-3456'),
//     new Member(5, '321654987', 'Emily', 'Brown', new Date('1983-12-05'), 'San Francisco', 'Maple Avenue', '1213', '555-8901', '555-4567'),
//     new Member(6, '654987321', 'Michael', 'Taylor', new Date('1995-09-30'), 'Seattle', 'Pine Street', '1415', '555-9012', '555-5678')
// ];

selectMember(member: Member) {
  this.selectedMember = member;
}

isFieldInvalid(field: string) {
  const control = this.memberForm.get(field);
  return control?.invalid && (control?.dirty || control?.touched);
}


submitForm() {
  
  if (this.memberForm.invalid) {
    return;
  }
  this.showForm=false
  const formData = this.memberForm.value as Member;
  this.membersService.addMember(formData).subscribe({
    
    next: (res) => {
      console.log(res)
      window.location.reload();

    },
    error: (error) => {
      console.log(error);
    }
  });


  // console.log(formData);
}

  
cancel(){
  this.showForm=false
}
 
}
