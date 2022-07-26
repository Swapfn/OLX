import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Token } from '../_models/token';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<Token>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http : HttpClient) { }

  login(model : any) :Observable<Token>{
<<<<<<< HEAD
    return this.http.post(this.baseUrl + 'account/login',model).pipe(
=======
    return this.http.post(this.baseUrl + 'Account/login',model).pipe(
>>>>>>> origin/Add-Post
      map((response : Token) => {
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
      map((user : Token) => {
        if (user) {
          localStorage.setItem("user",JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  setCurrentUser(user : Token) {
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
