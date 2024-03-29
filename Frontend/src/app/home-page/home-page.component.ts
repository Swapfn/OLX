import { Component, OnInit } from '@angular/core';
import { Post } from '../_models/post';
import { Pagination } from '../_models/pagination'; 
import { AccountService } from '../_services/account.service';
import { PostService } from '../_services/post.service';
import { Location } from '../_models/location';
import { Category } from '../_models/category';
import { SubCategory } from '../_models/subCategory';




@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  

  constructor(public postService:PostService, private accountService: AccountService) { 
    this.accountService.setCurrentUser;
  }

  ngOnInit(): void {
    this.loadPosts();
    this.getLocations();
    this.getAllCategories();

  }


  filter:Pagination={
    searchObject:{
      categoryId: 0,
      subCategoryId:0,
      locationId: 0,
      minPrice: 0,
      maxPrice: 0,
      title:"",
      description:""
    },
    pageNumber:1,
    pageSize:20,
    sortBy:"createdAt",
    sortDirection:"dec"
  }

  
  AllPosts:Post[];
  totalRecords:number;

  Today = new Date();

 

  loadPosts(){
    this.postService.getAllpagination(this.filter).subscribe((response: any) => {
      console.log(response);
      this.AllPosts = response.results;
      this.totalRecords=response.totalRecords;  
    })

  }

  createImgPath = (serverPath: any) => { 
    return `https://localhost:44355/${serverPath}`; 
  }



  // setItem(i:object){
  //   console.log("from home");
  //   console.log(i);
  //   this.postService.setItemsMaually(i);
  // }
  pageChanged(event:any){
    this.filter.pageNumber=event.page;
    this.loadPosts();
  }

  //________________________________category filter__________________________________________

  allCategories:Category[];

  getAllCategories(){
    this.postService.getCategories().subscribe(categories => this.allCategories=categories)
  }

  categorySelectedId:number;
  categorySelectedName:string;

  subcategorySelectedId:number;
  subcategorySelectedName:string;


  categorySelect(event){
    this.categorySelectedId = this.filter.searchObject.categoryId = event.target.value;
    this.categorySelectedName = event.target.title;
    this.subcategorySelectedId = this.filter.searchObject.subCategoryId = 0;
    
    this.loadPosts();
  }

  subCategorySelect(event,catId,catName){
    this.categorySelectedId = this.filter.searchObject.categoryId = catId ;
    this.categorySelectedName = catName;

    this.subcategorySelectedId = this.filter.searchObject.subCategoryId = event.target.value;
    this.subcategorySelectedName = event.target.title;
    this.loadPosts();
  }


  // subcategorySelected:SubCategory;

  // getSubcategoryById(){
  //   this.postService.getSubcategoryById(this.subcategorySelectedId).subscribe(s=>this.subcategorySelected=s)
  // }


  //________________________________category filter__________________________________________


  //________________________________location filter__________________________________________

  onlocationSelect(event){
    this.filter.searchObject.locationId=this.locationSelectedValue;
    this.loadPosts();
  }

  locationSelectedValue:number;

  locations:Location[];

  getLocations() {
    this.postService.getLocations().subscribe(locations => this.locations=locations);
  }
  //________________________________location filter__________________________________________


  //________________________________Search___________________________________________

  searchValue:string="";

  OnsearchText(){ 
    this.filter.searchObject.title= this.searchValue;
    this.filter.searchObject.description= this.searchValue;
    this.loadPosts();
  }

  //________________________________Search___________________________________________


  //________________________________Price filter___________________________________________

  OnPriceSet(Min,Max){
    
    if(Min==""){
      this.filter.searchObject.minPrice=0;
    }
    else{
      this.filter.searchObject.minPrice=Min;
    }

    if(Max==""){
      this.filter.searchObject.maxPrice=0;
    }
    else{
      this.filter.searchObject.maxPrice=Max;
    }
    

    this.loadPosts();
  }
    //________________________________Price filter___________________________________________


  


  // setItem(i:object){
  //   console.log("from home");
  //   console.log(i);
  //   this.PostService.setItemsMaually(i);
    
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


  favorite(event,i:object){
    event.stopPropagation();
    this.Fav=!this.Fav;
    this.FavPosts.push(i)
    console.log(this.FavPosts);
  }


}

 
