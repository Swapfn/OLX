import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<string>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http : HttpClient) { }

  login(model : any) :Observable<string>{
    return this.http.post(this.baseUrl + 'login',model).pipe(
      map((response : string) => {
        const user = response;
        if(user) {
          localStorage.setItem("user",JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      })
    )
  }

  register(model : any) {
    return this.http.post(this.baseUrl + 'register',model).pipe(
      map((user : string) => {
        if (user) {
          localStorage.setItem("user",JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  setCurrentUser(user : string) {
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  update(model : User) {
    return this.http.put(this.baseUrl + 'edit',model);
  }

  getUser() {
    return this.http.get<User>(this.baseUrl + "User/get");
  }

  delete() {
    return this.http.delete(this.baseUrl + "User/delete");
  }
}
