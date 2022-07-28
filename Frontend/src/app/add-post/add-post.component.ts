import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FileUploader } from 'ng2-file-upload';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Category } from '../_models/category';
import { Location } from '../_models/location';
import { Post } from '../_models/Post';
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
  post : Post={
    postId: null,
    title: '',
    description: '',
    createdAt: undefined,
    price: null,
    isNew: false,
    isNegotiable: false,
    isAvailable: false,
    subCategoryId: null,
    locationId: null,
    userID: null,
    subCategoryName: '',
    cityName: '',
    fullName: '',
    phoneNumber: null,
    minPrice: null,
    maxPrice: null,
    categoryId: null
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

  constructor(private accountService: AccountService, private postService: PostService, private toast: ToastrService,private router: Router) {
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

}
