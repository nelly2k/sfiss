import { APP_CONFIG, IAppConfig } from '../app.config';
import { Injectable, Inject } from "@angular/core";
import { Http, Response, Headers, RequestOptions, URLSearchParams } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Exercise, ExerciseSearchModel } from "./exercise.model";

import {PaginationResult} from "../common/pagination.model";

import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";

@Injectable()
export class ExerciseService {
    url:string;
    headers: Headers;

    constructor( @Inject(APP_CONFIG) private config: IAppConfig, private http: Http) {
        this.url = this.config.serviceUrl + ":" + this.config.exercisePort;
        this.headers = new Headers({ 'Content-Type': "application/json" });
    }   

    search(request:ExerciseSearchModel): Observable<PaginationResult<Exercise>> {
        return this.http.post(this.url, JSON.stringify(request), new RequestOptions({ headers: this.headers }))
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.json().error || "Server Error"));
    }
   

}