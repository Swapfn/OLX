import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from '../_models/Post';
import { AccountService } from '../_services/account.service';
import { PostService } from '../_services/post.service';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.css']
})
export class PostDetailsComponent implements OnInit {

  id: any;

  constructor(private PostService:PostService,private AccountService:AccountService,private route:ActivatedRoute) { 
    this.id = this.route.snapshot.paramMap.get("id");
  }

  ngOnInit(): void {
    // this.loadPost();
    // this.getItem();
  }

  Post:Post;

  // loadPost(){
  //  this.PostService.getPost(this.id).subscribe(p=>{this.Post=p;});
  // }

  // Item=this.PostService.Item;


  // getItem(){
  //   this.Item=this.PostService.getItemsMaually();
  //   console.log("from details");
  // }
 




}
