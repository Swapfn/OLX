import { Component, TemplateRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-profile-edit',
  templateUrl: './profile-edit.component.html',
  styleUrls: ['./profile-edit.component.css']
})
export class ProfileEditComponent implements OnInit {
  //Token: string;
  @ViewChild("ProfileEditForm") editForm: NgForm;
  model: User = {
    userName: "", firstName: "", lastName: "", aboutMe: "", phone: null, email: "",
    password: '',
    confirmPassword: ''
  };  //The model containing data to be edited
  modalRef?: BsModalRef; //for the ngx-bootstrap modal
  constructor(private modalService: BsModalService, private router: Router, private accountService: AccountService, private toast: ToastrService) {
    //this.accountService.currentUser$.pipe(take(1)).subscribe(token => this.Token=token);
  }

  openModal(template: TemplateRef<any>) {   //For ngx modal
    this.modalRef = this.modalService.show(template);
  }


  ngOnInit(): void {
    this.getUser();
  }

  getUser() {
    this.accountService.getUser().subscribe(user => this.model = user);
  }

  update() {
    if (this.model.userName == "" || this.model.phone == null || this.model.email == "" || this.model.firstName == "" || this.model.lastName == "") {
      this.toast.error("Please fill all required fields");
    }
    else {
      this.accountService.update(this.model).subscribe(() => {
        this.toast.success("Profile updated successfully");
        this.editForm.reset(this.model);
      })
    }
  }

  delete() {
    this.accountService.delete().subscribe(() => {
      this.toast.success("Profile deleted successfully");
      this.router.navigateByUrl("/welcome");
      this.accountService.logout();
      this.modalRef?.hide();
    });
  }

}
