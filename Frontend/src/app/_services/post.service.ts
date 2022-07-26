import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
<<<<<<< HEAD
import { Post } from '../_models/Post';
=======
import { Post } from '../_models/post';
>>>>>>> origin/Add-Post

@Injectable({
  providedIn: 'root'
})

export class PostService {
  baseUrl = environment.apiUrl;

<<<<<<< HEAD
  constructor(private http: HttpClient) { }
  getAllPosts() {
    return this.http.get<Post[]>(this.baseUrl + 'post');
  }

  getPost(id: number) {
    return this.http.get<Post>(this.baseUrl + 'post/' + id);
  }
}


=======
  constructor(private http : HttpClient) { }

  getAllPosts(){
    return this.http.get<Post[]>(this.baseUrl+'post');
   }
  
   getPost(id:number){
    return this.http.get<Post>(this.baseUrl+'post/'+id);
   }
}

>>>>>>> origin/Add-Post


