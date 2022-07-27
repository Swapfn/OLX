import { Component, OnInit } from '@angular/core';
import { Post } from '../_models/post';
import { AccountService } from '../_services/account.service';
import { PostService } from '../_services/post.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  AllPosts:Post[];

  constructor(private PostService:PostService, private accountService: AccountService) { 
    this.accountService.setCurrentUser;
  }

  ngOnInit(): void {
    // this.loadPosts();
  }

  TotaPostsNumb(){
    return this.AllPosts.length;
  }

  // loadPosts(){
  //   this.PostService.getAllPosts().subscribe(p=>{this.AllPosts=p;})
  // }


 


  Items=
  [
    {OwnerId:1 ,Id:12, type:"", title:"DeLonghi airfryer multifry FH1173 Digital", describtion:"", price:"5200", nego_Price:true ,city:"Alexandria",area:"Agami" ,
           photo:[
             {src:"/assets/images/id1/airfryer.jpg"},
             {src:"/assets/images/id1/3085.jpg"},
             {src:"/assets/images/id1/3086.jpg"},
             {src:"/assets/images/id1/3087.jpg"},
             {src:"/assets/images/id1/3089.jpg"}
            ]
            ,condition:"used", available:true},

    {OwnerId:5 ,Id:52,type:"", title:"Echo Dot (4th generation) Smart speaker with clock and Alexa(Arabic)", describtion:"", price:"1900", nego_Price:false ,city:"Cairo",area:"Rehab city" , 
            photo:[
             {src:"/assets/images/id2/speakers.jpg"},
             {src:"/assets/images/id2/3088.jpg"},
             {src:"/assets/images/id2/3018.jpg"},
             {src:"/assets/images/id2/3080.jpg"}
            ]
            ,condition:"new", available:true},

    {OwnerId:5 ,Id:53,type:"", title:"Bicycle aluminum size 6 in good condition", describtion:"", price:"2300", nego_Price:false , city:"Ismailia",area:"ismailia city" ,
            photo:[
             {src:"/assets/images/id3/bicycle.jpg"},
             {src:"/assets/images/id3/308503.jpg"},
             {src:"/assets/images/id3/308505.jpg"}
            ]
            ,condition:"used", available:true},

    {OwnerId:8 ,Id:84,type:"", title:"Xbox One S 1TB Console with Wireless Controller", describtion:"", price:"4200", nego_Price:true , city:"Giza",area:"Mohandessin" ,
            photo:[
             {src:"/assets/images/id4/30877.jpg"},
             {src:"/assets/images/id4/30888.jpg"}
            ]
            ,condition:"used", available:true},
  ]


 


  //_______________________favorite post____________________________

  Fav:boolean=false;

  FavPosts:object[]=[];


  favorite(i:object){
    this.Fav=!this.Fav;
    this.FavPosts.push(i)
    console.log(this.FavPosts);
  }


}

 

