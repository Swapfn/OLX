import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  loggedIn: boolean;
  currentUser$: Observable<string>;

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


  // constructor() { }

  // ngOnInit(): void {
  // }
  // //______________________Location Filter_________________________________________
  // EgyCities=["Alexandria","Awan","Asyut","Beheira","Beni Suef","Cairo","Dakahlia","Damietta",
  // "Faiyum","Gharbia","Giza","Ismailia","Kafr El Sheikh","Luxor","Matruh","Minya","Monufia","New Valley",
  // "North Sinai","Port Said","Qalyubia","Qena","Red Sea","Sharqia","Sohag","South Sinai","Suez"]

  // locationSelectedValue:string="Egypt";

  // @Output()
  // locationselect:EventEmitter<string> = new EventEmitter<string>();

  // onlocationSelect(e:any){
  //   this.locationselect.emit(this.locationSelectedValue)
  //   //console.log(this.locationSelectedValue);
  // }


  // //________________________________Search___________________________________________

  // searchValue:string="";

  // @Output()
  // searchText:EventEmitter<string>= new EventEmitter<string>();

  // OnsearchText(){
  //   this.searchText.emit(this.searchValue);

  // }






}
