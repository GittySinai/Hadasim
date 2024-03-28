import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Member } from '../models/memberModel';
import { MedicalEvent } from '../models/medicalEvents';

@Injectable({
  providedIn: 'root'
})
export class MembersService {

  constructor(private httpClient: HttpClient) { }

  private baseUrl = 'https://localhost:7218'; 

  getMembers(): Observable<any[]> {
    return this.httpClient.get<any[]>(`${this.baseUrl}/api/Members/GetMembers`);
  }
    getMemberByTZ(tz: string): Observable<Member> {
    return this.httpClient.get<Member>(`${this.baseUrl}/api/Members/GetMemberByTZ/${tz}`);
  }
  updateMember(memberData: Member): Observable<any[]> {
    
    return this.httpClient.put<any[]>(`${this.baseUrl}/api/Members/UpdateMember`, memberData);
}
deleteMember(tz: string): Observable<Member> {
  return this.httpClient.delete<Member>(`${this.baseUrl}/api/Members/deleteMember/${tz}`);
}
addMember(memberData: Member): Observable<any> {
  
  return this.httpClient.post<any[]>(`${this.baseUrl}/api/Members/AddMember`, memberData);
}

addMedicalEvent(medicalEventData: MedicalEvent): Observable<any> {
  
  return this.httpClient.post<any[]>(`${this.baseUrl}/api/Members/AddMedicalEvent`, medicalEventData);
}
addVaccinEvent(vaccineEventData: MedicalEvent): Observable<any> {
  
  return this.httpClient.post<any[]>(`${this.baseUrl}/api/Members/AddVaccinEvent`, vaccineEventData);
}
// updateHishtalmut(updateHishtalmut: Hishtalmut): Observable<any> {
//   return this.httpClient.post(`${this.rootApi}UpdateHishtalmut`, updateHishtalmut);
// }
}

