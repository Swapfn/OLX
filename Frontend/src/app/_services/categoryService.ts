import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';

import { Category } from '../_models/category';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<string>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {}

  getCategories() {
    return this.http.get<Category[]>('http://localhost/WebAPI/Categories');
    // return this.http.get<Category[]>(this.baseUrl + 'Categories');
  }
}
