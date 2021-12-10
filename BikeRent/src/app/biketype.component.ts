import { Component, OnInit } from '@angular/core';
import { BikeTypeService } from './biketype.service';
import { BikeType } from './biketype';

@Component({
    selector: 'biketype',
    templateUrl: './biketype.html',
    providers: [BikeTypeService]
})
export class BikeTypeComponent implements OnInit {

    biketypes: Array<BikeType>;                
 
    constructor(private serv: BikeTypeService) { 
        this.biketypes = new Array<BikeType>();
    }
 
    ngOnInit() {
        this.loadBikeType();
    }

    loadBikeType() {
        this.serv.getBikeType()
            .subscribe((data: any) => {
                this.biketypes = data;
            });
    }
}