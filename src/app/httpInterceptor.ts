
import { Component} from '@angular/core';
import { map, filter, tap } from 'rxjs/operators';
import { NgModule, Injectable } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {
    HttpClient,
    HTTP_INTERCEPTORS,
    HttpEvent,
    HttpRequest,
    HttpResponse,
    HttpHandler,
    HttpHeaders,
    HttpClientModule,
    HttpClientJsonpModule
  } from '@angular/common/http'
import { Observable } from 'rxjs'
//import { SessionTimeOut } from './com/services/logOut';

@Injectable()
export class BOInterceptor {
    constructor() { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        console.log("intercepted request ... ");
        //for (var key in req.body) {
        //    if (req.body[key])
        //        delete this.searchData[key];
        //    }
        const headers = new HttpHeaders({'nameUser':"ester pirian"});
         const authReq = req.clone({ headers: headers });
        return next.handle(authReq).pipe(
            tap(event => {
                if (event instanceof HttpResponse) {
                  console.log("intercepted response ... ")
                }
            }, error => {
                    console.error('NICE ERROR', error)
        })
            )
    }
}

@NgModule({
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: BOInterceptor, multi: true }
    ]
})
export class JsonpInterceptingModule { }
