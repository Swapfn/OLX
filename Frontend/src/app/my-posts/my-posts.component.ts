import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Post } from '../_models/post';
import { PostService } from '../_services/post.service';

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

  constructor(private http: HttpClient, private postService: PostService) { }

  ngOnInit(): void {
    this.getAvAds();
    this.getUnAvAds();
  }

  Items =
    [
      {
        OwnerId: 1, Id: 12, type: "", title: "DeLonghi airfryer multifry FH1173 Digital", describtion: "", price: "5200", nego_Price: true, city: "Alexandria", area: "Agami",
        photo: [
          { src: "/assets/images/id1/airfryer.jpg" },
          { src: "/assets/images/id1/3085.jpg" },
          { src: "/assets/images/id1/3086.jpg" },
          { src: "/assets/images/id1/3087.jpg" },
          { src: "/assets/images/id1/3089.jpg" }
        ]
        , condition: "used", available: true
      }
    ]

  getAvAds() {
    this.postService.getMyAvailableAds().subscribe(posts => this.AvailablePosts=posts);
  }

  getUnAvAds() {
    this.postService.getMyUnvailabaleAds().subscribe(posts => this.UnvailablePosts=posts);
  }

  alltrue() {
    this.available = this.unavailable = true;
  }

  createImgPath = (serverPath: any) => { 
    return `https://localhost:44355/${serverPath}`; 
  }

}
