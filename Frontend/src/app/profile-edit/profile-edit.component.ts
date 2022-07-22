import { Component,TemplateRef , OnInit } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Profile } from '../_models/profile';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-profile-edit',
  templateUrl: './profile-edit.component.html',
  styleUrls: ['./profile-edit.component.css']
})
export class ProfileEditComponent implements OnInit {
  kalam: string="" ;  //To get char count in text area
  user : Profile;
  model : Profile = {username:"",aboutMe:"",phoneNumber:null,email:""};  //The model containing data to be edited
  modalRef?: BsModalRef;
  constructor(private modalService: BsModalService,private accountService : AccountService, private toast: ToastrService) { }

  openModal(template: TemplateRef<any>) {   //For ngx modal
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit(): void {
  }

  update() {
    if(this.model.username=="" || this.model.phoneNumber==null || this.model.email=="")
    {
      this.toast.error("Please fill all required fields");
    } 
    else {
      console.log(this.model);
      //this.accountService.update(this.model);
    }
  }

}
