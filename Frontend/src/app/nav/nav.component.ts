import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Token } from '../_models/token';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  loggedIn: boolean;
  currentUser$: Observable<Token>;

  constructor(public accountService: AccountService, private router: Router, private toast: ToastrService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response);
        this.loggedIn = true;
        this.router.navigateByUrl("/home");
      },
      error: error => {
        console.log(error);
        this.toast.error(error.error);
      }
    })
  }

  logout() {
    this.accountService.logout();
    this.loggedIn = false;
    this.router.navigateByUrl("/");
  }

  getCurrentUser() {
    this.accountService.currentUser$.subscribe({
      next: response => {
        this.loggedIn = !!response;
      },
      error: error => {
        console.log(error);
      }
    })
  }



  //________________________________Search___________________________________________

  searchValue:string="";

  OnsearchText(){ 
  }






}
