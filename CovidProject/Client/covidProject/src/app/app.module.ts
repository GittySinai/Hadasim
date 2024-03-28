import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { DropdownModule } from 'primeng/dropdown';
import { CheckboxModule } from 'primeng/checkbox';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'
import { ButtonModule } from 'primeng/button';
import { MembersListComponent } from './components/members-list/members-list.component';
import { MemberComponent } from './components/member/member.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DialogModule } from 'primeng/dialog';
import { CalendarModule } from 'primeng/calendar';
import { ImageUploadComponent } from './components/image-upload/image-upload.component';
import { HomeComponent } from './components/home/home.component';




@NgModule({
  declarations: [

    AppComponent,
    MembersListComponent,
    MemberComponent,
    ImageUploadComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    InputTextModule,
    InputNumberModule,
    DropdownModule,
    CheckboxModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    ButtonModule,
    DialogModule,
    CalendarModule


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
