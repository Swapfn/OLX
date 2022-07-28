import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Category } from '../_models/category';
import { Post } from '../_models/post';

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
    return this.http.get<Post>(this.baseUrl+'post/'+id);
   }

  getCategories() {
    return this.http.get<Category>(this.baseUrl+'categories/');
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
    
  // }
}




