import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Bike } from './bike';

@Injectable()
export class BikeService {

    private url = "/api/bike";

    constructor(private http: HttpClient) {
    }

    getBikes() {
        return this.http.get<Array<Bike>>(this.url);
    }

    getBike(id: string) {
        return this.http.get(this.url + '/' + id);
    }

    getFreeBike() {
        return this.http.get<Array<Bike>>(this.url + '/freebike');
    }   

    rentBike(id: string, status: boolean) {
        return this.http.put('/api/bike/' + id + '?' + 'status=' + status,id);
    }
 
    createBike(bike: Bike) {
        return this.http.post(this.url, bike);
    }
 
    updateBike(bike: Bike) {
        return this.http.put(this.url, bike);
    }
 
    deleteBike(id: string) {
        return this.http.delete(this.url + '/' + id);
    }
}
