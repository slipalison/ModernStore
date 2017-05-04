import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class DataService {

    private serviceUrl: string = 'http://localhost:9652/';
    constructor(private http: Http) { }

    createUser(data: any) {
          return this.http.post(this.serviceUrl+ 'api/v1/customer', data)
          .map((res: Response) => res.json());
    }

    authenticate(data: any) {
        var dt = "grant_type=password&username=" + data.username + "&password=" + data.password;
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post(this.serviceUrl + 'v1/authenticate', dt, options).map((res: Response) => res.json());
    }
    validateToken(token:string){
        return true; 
    }

    getCourses() {
        return this.http.get('http://abt-api.azurewebsites.net/api/courses')
            .map((res: Response) => res.json());
    }
}