import { isNgTemplate } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from '../_models/post';
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
    this.getitem();
    
  }

  Post:Post;

  loadPost(){
   this.PostService.getPost(this.id).subscribe(p=>{this.Post=p;});
  }

  createImgPath = (serverPath: any) => { 
    return `https://localhost:44355/${serverPath}`; 
  }



  // _________________________Manually_____________________________________

 Item:any;
 price:number=20;

  getitem(){
    this.Item=this.PostService.getItemsMaually();
  }








}
