import { Component, Input } from '@angular/core';
import { Member } from 'src/app/models/memberModel';

@Component({
  selector: 'app-image-upload',
  templateUrl: './image-upload.component.html',
  styleUrls: ['./image-upload.component.scss'] // Specify SCSS file here
})
export class ImageUploadComponent {

  uploadedImage: string = ''; 
  @Input() member!: Member;

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.uploadedImage = e.target.result;
      localStorage.setItem('uploadedImage'+this.member.tz, this.uploadedImage);
    };
    reader.readAsDataURL(file);
  }

  ngOnInit() {
    const storedImage = localStorage.getItem('uploadedImage'+this.member.tz);
    if (storedImage) {
      this.uploadedImage = storedImage;
    }
  }
}
