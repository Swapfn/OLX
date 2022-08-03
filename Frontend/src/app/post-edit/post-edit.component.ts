import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from '../_models/post';
import { AccountService } from '../_services/account.service';
import { PostService } from '../_services/post.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.css']
})
export class PostEditComponent implements OnInit {
  @ViewChild("PostEditForm") editForm: NgForm;
  id: any;
  model: Post={
    postId: 0,
    title: '',
    description: '',
    createdAt: new Date(),
    price: 0,
    isNew: false,
    isNegotiable: false,
    isAvailable: false,
    categoryId: 0,
    subCategoryId: 0,
    locationId: 0,
    userID: 0,
    subCategoryName: '',
    cityName: '',
    fullName: '',
    phoneNumber: 0,
    aboutMe:'',
    minPrice: 0,
    maxPrice: 0,
    postImage: []
  }
  modalRef?: BsModalRef; //for the ngx-bootstrap modal


  constructor(private postService:PostService,private accountService:AccountService,private route:ActivatedRoute,private modalService: BsModalService,private toast: ToastrService) {
    this.id = this.route.snapshot.paramMap.get("id");
   }

  ngOnInit(): void {
    this.getPost();
  }

  getPost() {
    this.postService.getPost(this.id).subscribe(post => this.model=post);
  }

  openModal(template: TemplateRef<any>) {   //For ngx modal
    this.modalRef = this.modalService.show(template);
  }

  // update() {
  //   if (this.model.userName == "" || this.model.phone == null || this.model.email == "" || this.model.firstName == "" || this.model.lastName == "") {
  //     this.toast.error("Please fill all required fields");
  //   }
  //   else {
  //     this.accountService.update(this.model).subscribe(() => {
  //       this.toast.success("Profile updated successfully");
  //       this.editForm.reset(this.model);
  //     })
  //   }
  // }

  // delete() {
  //   this.accountService.delete().subscribe(() => {
  //     this.toast.success("Profile deleted successfully");
  //     this.route.navigateByUrl("/welcome");
  //     this.accountService.logout();
  //     this.modalRef?.hide();
  //   });
  // }

}
