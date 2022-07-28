import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Post } from '../_models/Post';
@Injectable({
  providedIn: 'root'
});

export class PostService {
  baseUrl = environment.apiUrl;

  constructor(private http : HttpClient) { }
}
 getAllPosts(){
  return this.http.get<Post[]>(this.baseUrl+'post');
 }

 getPost(id:number){
  return this.http.get<Post>(this.baseUrl+'post/'+id);
 }


