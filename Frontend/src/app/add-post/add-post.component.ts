import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { FileUploader } from 'ng2-file-upload';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Category } from '../_models/category';
import { Location } from '../_models/location';
import { Post } from '../_models/post';
import { PostImage } from '../_models/postImage';
import { SubCategory } from '../_models/subCategory';
import { Token } from '../_models/token';
import { AccountService } from '../_services/account.service';
import { PostService } from '../_services/post.service';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css']
})
export class AddPostComponent implements OnInit {
  selectedFiles: any = null;
  dbPaths: string[];
  @Output() public onnUploadFinished = new EventEmitter();
  post : Post={
    postId: 0,
    title: '',
    description: '',
    createdAt: new Date(),
    price: null,
    isNew: false,
    isNegotiable: false,
    isAvailable: true,
    subCategoryId: null,
    locationId: null,
    userID: 0,
    subCategoryName: '',
    cityName: '',
    fullName: null,
    phoneNumber: null,
    minPrice: 0,
    maxPrice: 0,
    categoryId: null,
    postImage: []
  };
  uploader: FileUploader;
  hasBaseDropzoneOver = false;
  baseUrl = environment.apiUrl;
  token: string;
  categories: Category[];
  subcategories: SubCategory[];
  locations: Location[];
  category1: Category={
    categoryID: null,
    categoryName: '',
    subCategories: [{categoryID: null,
      subCategoryID: null,
      subCategoryName:''}]
  }
  // categoryID: number;

  constructor(private accountService: AccountService, private postService: PostService, private toast: ToastrService,private router: Router, private http: HttpClient) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(token => this.token=token);
   }

  ngOnInit(): void {
    // this.initializeUploader();
    this.getCategories();
    // this.getCategoryByID();
    this.getLocations();
  }

  fileOverBase(e : any) {
    this.hasBaseDropzoneOver = e;
  }

  // initializeUploader() {
  //   this.uploader = new FileUploader({
  //     url: this.baseUrl + 'EndpointBta3hom',
  //     authToken: "Bearer "+ this.token,
  //     isHTML5: true,
  //     allowedFileType: ['image'],
  //     removeAfterUpload: true,
  //     autoUpload: false,
  //     maxFileSize: 10*1024*1024
  //   });

  //   this.uploader.onAfterAddingFile = (file) => {
  //     file.withCredentials = false;
  //   }

  //   this.uploader.onSuccessItem = (item , response , statues , headers) => {
  //     if(response) {
  //       const photo = JSON.parse(response);
  //       this.post.photos.push(photo);
  //     }
  //   }
  // }

  getCategories() {
    this.postService.getCategories().subscribe(categories => this.categories=categories);
  }

  getCategoryByID() {
    this.postService.getCategoryById(this.post.categoryId.toString()).subscribe(category => this.category1=category);
    console.log(this.post.categoryId);
  }

  getLocations() {
    this.postService.getLocations().subscribe(locations => this.locations=locations);
  }

  addPost() {
    // console.log(this.post);
    this.onCreate();
    this.postService.addPost(this.post).subscribe({
      next: () => {
        this.toast.success("Post added successfully");
        this.router.navigateByUrl("/home");
      },
      error: error => {
        console.log(error);
        this.toast.error(error.error.message);
      }
    })
  }
  onFileSelected(event: any) {
    this.selectedFiles = <File>event.target.files;
  }
  onUpload() {
    if (this.selectedFiles.length === 0) {
      return;
    }
    let filesToUpload: File[] = this.selectedFiles;
    const filedata = new FormData();
    Array.from(filesToUpload).map((file) => {
      filedata.append('image', file, file.name);
    });

    this.http.post('https://localhost:44355/PostImage/upload', filedata)
    .subscribe((res:any) => this.dbPaths=res.dbPaths);
  }

  onCreate() {//add post image
    // this.post.postImage.push
    // this.post.postId = 3;//post id =3 
    let image: PostImage;
    for (var path of this.dbPaths) {
      image.imageURL = path;
      this.http.post('https://localhost:44355/PostImage', this.post)
        .subscribe((event: any) => {
          if (event.type === HttpEventType.Response) {
          }
        });
      this.post.postImage.push(image);
    }
  }

}
