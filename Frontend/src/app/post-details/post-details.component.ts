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
    this.loadPost();
  }

  Post:Post;

  loadPost(){
   this.PostService.getPost(this.id).subscribe(p=>{this.Post=p;});
  }
 




}
