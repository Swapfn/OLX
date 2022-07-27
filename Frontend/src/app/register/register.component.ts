import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Register } from '../_models/register';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model : Register={
    username: '',
    fName: '',
    lName: '',
    email: '',
    phone: '',
    password: '',
    confirmPassword: '',
    aboutMe: ''
  };

  constructor(private accountService : AccountService, private toast: ToastrService, private route: Router) { }

  ngOnInit(): void {
  }

  register() {
    this.accountService.register(this.model).subscribe({
      next : response => {
        console.log(response);
        this.route.navigateByUrl("/home");
        this.toast.success(`Welcome ${this.model.username}`)
        this.cancel();
      } ,
      error : error => {
        this.toast.error(error.error);
      }
    })
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
