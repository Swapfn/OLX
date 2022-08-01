import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ProfileEditComponent } from './profile-edit/profile-edit.component';
import { NavComponent } from './nav/nav.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LocationFilterComponent } from './location-filter/location-filter.component';
import { SharedModule } from './_modules/shared.module';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { MyPostsComponent } from './my-posts/my-posts.component';
import { AddPostComponent } from './add-post/add-post.component';
import { PostDetailsComponent } from './post-details/post-details.component';
import { FooterComponent } from './footer/footer.component';
import { PostEditComponent } from './post-edit/post-edit.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavComponent,
    RegisterComponent,
    ProfileEditComponent,
    NavComponent,
    HomePageComponent,
    LocationFilterComponent,
    MyPostsComponent,
    AddPostComponent,
    PostDetailsComponent,
    FooterComponent,
    PostEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule,
 
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass:JwtInterceptor, multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
