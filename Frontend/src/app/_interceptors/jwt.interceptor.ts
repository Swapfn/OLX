import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { Token } from '../_models/token';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private accountService: AccountService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let currentUser: string;
    this.accountService.currentUser$.pipe(take(1)).subscribe((user: Token) => currentUser=user.token);

    if(currentUser) {
      request =  request.clone({
        setHeaders: {
          Authorization: `Bearer ${currentUser}`
        }
      })
    }

    return next.handle(request);
  }
}
