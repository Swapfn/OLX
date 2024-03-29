import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Category } from '../_models/category';
import { Location } from '../_models/location';
import { Post } from '../_models/post';
import { Pagination } from '../_models/pagination';
import { NavComponent } from '../nav/nav.component';
import { SubCategory } from '../_models/subCategory';

@Injectable({
  providedIn: 'root'
})

export class PostService {
  baseUrl = environment.apiUrl;

  constructor(private http : HttpClient) { }

  getAllPosts(){
    return this.http.get<Post[]>(this.baseUrl+'post');
   }
  
  getPost(id:number) {
    return this.http.get<Post>(this.baseUrl+'posts/'+id);
    
   }

  getCategories() {
    return this.http.get<Category[]>(this.baseUrl +'categories/');
  }

  getCategoryById(id: string) {
    return this.http.get<Category>(this.baseUrl +'categories/'+id);
  }

  getSubcategoryById(id:number){
    return this.http.get<SubCategory>(this.baseUrl+"/SubCategories"+id);
  }

  getLocations() {
    return this.http.get<Location[]>(this.baseUrl +'locations/');
  }

  addPost(model: Post) {
    return this.http.post(this.baseUrl + "posts/add",model);
  }

  getMyAvailableAds() {
    return this.http.get<Post[]>(this.baseUrl + "getavailableposts/");
  }

  getMyUnvailabaleAds() {
    return this.http.get<Post[]>(this.baseUrl + "getunavailableposts/");
  }



  //  Item:object;

  //  setItemsMaually(I:object){
  //   this.Item=I;
  //   console.log("from set Service");
  //   console.log(I);
  //  }

  //  getItemsMaually(){
  //   console.log("from get Service");
  //   return this.Item;
  //   return this.http.get<Location[]>(this.baseUrl+'locations/');
    
  // }

  getAllpagination(filter:Pagination){
    return this.http.post(this.baseUrl+'Posts',filter);
  }

  updatePassword(model : any) {
    return this.http.post(this.baseUrl+'account/changePassword',model);
  }


  // Item:object;

  // setItemsMaually(I:object){
  //   this.Item=I;
  //   console.log("from set Service");
  //   console.log(I);
  // }

  // getItemsMaually(){
  //   console.log("from get Service");
  //   return this.Item;
    
  // }
}




