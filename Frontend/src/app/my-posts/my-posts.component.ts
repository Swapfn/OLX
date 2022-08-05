import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Post } from '../_models/post';
import { PostService } from '../_services/post.service';
import { AdsPagination } from'../_models/AdsPagination';


@Component({
  selector: 'app-my-posts',
  templateUrl: './my-posts.component.html',
  styleUrls: ['./my-posts.component.css']
})
export class MyPostsComponent implements OnInit {
  available: boolean=true;
  unavailable: boolean;
  AvailablePosts: Post[]= [];
  UnvailablePosts: Post[]= [];
  AllPosts:Post[];
  totalRecords:number;


  Adsfilter:AdsPagination={
    searchObject:{
  
      isAvailable:null
      
    },
    pageNumber:1,
    pageSize:20,
    sortBy:"createdAt",
    sortDirection:"dec"
  }

  constructor(private http: HttpClient, private postService: PostService) { }

  ngOnInit(): void {
    this.getAvAds();
    this.getUnAvAds();
    this.getAllMyAds()
  }

  
  getAvAds() {
    this.postService.getMyAvailableAds().subscribe(posts => this.AvailablePosts=posts);
  }

  getUnAvAds() {
    this.postService.getMyUnvailabaleAds().subscribe(posts => this.UnvailablePosts=posts);
  }

  alltrue() {
    this.available = this.unavailable = true;
  }

  getAllMyAds(){
    this.postService.getAllMyAds(this.Adsfilter).subscribe((response: any) => {
      console.log(response);
      this.AllPosts = response.results;
      this.totalRecords=response.totalRecords;
    })
  }

  createImgPath = (serverPath: any) => { 
    return `https://localhost:44355/${serverPath}`; 
  }


 

  // pageChanged(event:any){
  //   this.Adsfilter.pageNumber=event.page;
  //   this.loadPosts();
  // }

}
