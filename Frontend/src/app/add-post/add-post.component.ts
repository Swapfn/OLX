import { Component, OnInit } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Post } from '../_models/post';
import { Token } from '../_models/token';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css']
})
export class AddPostComponent implements OnInit {
  post : Post;
  uploader: FileUploader;
  hasBaseDropzoneOver = false;
  baseUrl = environment.apiUrl;
  token: string;

  constructor(private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(token => this.token=token);
   }

  ngOnInit(): void {
    this.initializeUploader();
  }

  fileOverBase(e : any) {
    this.hasBaseDropzoneOver = e;
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'EndpointBta3hom',
      authToken: "Bearer "+ this.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10*1024*1024
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    }

    this.uploader.onSuccessItem = (item , response , statues , headers) => {
      if(response) {
        const photo = JSON.parse(response);
        this.post.photos.push(photo);
      }
    }
  }

}
