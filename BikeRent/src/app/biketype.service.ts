import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { BikeType } from './biketype';

@Injectable()
export class BikeTypeService {

    private url = "/api/biketype";

    constructor(private http: HttpClient) {
    }

    getBikeType() {
        return this.http.get<Array<BikeType>>(this.url);
    }
   
}