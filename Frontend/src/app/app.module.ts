import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { RegisterComponent } from './register/register.component';
import { ProfileEditComponent } from './profile-edit/profile-edit.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NavComponent } from './nav/nav.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LocationFilterComponent } from './location-filter/location-filter.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavComponent,
    RegisterComponent,
    ProfileEditComponent
    NavComponent,
    HomePageComponent,
    LocationFilterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    ModalModule.forRoot()
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
