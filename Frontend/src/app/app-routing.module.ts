import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { HomeComponent } from './home/home.component';
import { ProfileEditComponent } from './profile-edit/profile-edit.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: "", component: HomeComponent },
  {
    path: "",
    //runGuardsAndResolvers: 'always',
    //canActivate: [AuthGuard],
    children: [
      { path: "profile", component: ProfileEditComponent },
      { path: "welcome", component: HomePageComponent }
    ]
  },
  { path: "**", component: HomeComponent, pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
