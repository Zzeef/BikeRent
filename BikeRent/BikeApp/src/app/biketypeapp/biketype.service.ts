import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BikeType } from './biketype';
import { throwError } from 'rxjs';
import {map, catchError } from 'rxjs/operators';

@Injectable()
export class BikeTypeService {

    private url = "/api/biketype";

    constructor(private http: HttpClient) {
    }

    getBikeTypes() {
        return this.http.get<Array<BikeType>>(this.url);
    }

    getBikeType(id: string) {
        console.log(this.http.get<BikeType>(this.url + '/' + id));
        return this.http.get<BikeType>(this.url + '/' + id);
    }
}