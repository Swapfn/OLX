import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;

  constructor() { }

  ngOnInit(): void {
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }


  cancelRegisterMode(event : boolean) {
    this.registerMode = event;
  }

}
 //_______________________favorite post____________________________

 Fav:boolean=false;

 FavPosts:object[]=[];


 favorite(i:object){
   this.Fav=!this.Fav;
   this.FavPosts.push(i)
 }


}
