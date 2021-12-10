import { Component} from '@angular/core';
import { Bike } from '../bikeapp/bike';
import { BikeType } from './biketype';
import { BikeTypeService } from './biketype.service';
 
@Component({
    selector: 'biketype',
    templateUrl: './biketype.html'
})
export class BikeTypeComponent {

    biketype: BikeType|null = null;
    biketypes: BikeType[]; 

    constructor(private serv: BikeTypeService) {
        this.biketypes = new Array<BikeType>();
     }
 
    ngOnInit() {
        this.load();
    }
    load() {
        this.serv.getBikeTypes().subscribe((data: BikeType[]) => this.biketypes = data);
    }
 }