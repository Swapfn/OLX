import { Component,TemplateRef , OnInit } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-profile-edit',
  templateUrl: './profile-edit.component.html',
  styleUrls: ['./profile-edit.component.css']
})
export class ProfileEditComponent implements OnInit {
  kalam: string="" ;  //To get char count in text area
  model : any;  //The model containing data to be edited
  modalRef?: BsModalRef;
  constructor(private modalService: BsModalService) { }

  openModal(template: TemplateRef<any>) {   //For ngx modal
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit(): void {
  }

}
