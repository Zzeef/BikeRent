import {TemplateRef, ViewChild} from '@angular/core';
import { Component, OnInit} from '@angular/core';
import { Bike } from './bike';
import { BikeService } from './bike.service';
import { BikeTypeService } from '../biketypeapp/biketype.service';
import { BikeType } from '../biketypeapp/biketype';
 
@Component({
    selector: 'bike',
    templateUrl: './bike.html'
})
export class BikeComponent implements OnInit {

    @ViewChild('readOnlyTemplate', {static: false}) readOnlyTemplate: TemplateRef<any>|undefined;
    @ViewChild('editTemplate', {static: false}) editTemplate: TemplateRef<any>|undefined;

    editedBike: Bike|null = null; 
    bikes: Bike[]; 
    rentBike: Bike[];
    biketype: BikeType[];
    isNewRecord: boolean = false;
    statusMessage: string = "";

    constructor(private serv: BikeService, private biketypeServ: BikeTypeService) {
        this.bikes = new Array<Bike>();
        this.rentBike = new Array<Bike>();
        this.biketype = new Array<BikeType>();
     }
 
    ngOnInit() {
        this.loadBikes();
    }
    private loadBikes() {
        this.serv.getFreeBike().subscribe((data: Bike[]) => this.bikes = data);
        this.serv.getBikes().subscribe((data: Bike[]) => this.rentBike = data);
        this.biketypeServ.getBikeTypes().subscribe((data: BikeType[]) => this.biketype = data);       
    }

    getType(id: string) {
        return this.biketype.find(item=> item.id == id)?.name;
    }

    rent(bike: Bike) {
        this.serv.rentBike(bike.id, true).subscribe(data => {
            this.statusMessage = 'Аренда добавлена',
            this.loadBikes();
        });
    }

    cancelRent(bike: Bike) {
        this.serv.rentBike(bike.id, false).subscribe(data => {
            this.statusMessage = 'Аренда отменена',
            this.loadBikes();
        });     
    }

    sumRent(rentBikes: Bike[]) {
        let sum = 0;
        for(let i of Object.values(rentBikes)) {
            sum += i.rentprice;
        }
        return sum;
    }

    addBike(bike: Bike) {
        this.editedBike = new Bike(bike.id, bike.name,bike.biketypeid,bike.rentprice,bike.isrent);
        this.bikes.push(this.editedBike);
        this.isNewRecord= true;
    }

    editBike(bike: Bike) {
        this.editedBike = new Bike(bike.id, bike.name,bike.biketypeid,bike.rentprice,bike.isrent);
    }

    loadTemplate(bike: Bike) {
        if(this.editedBike && this.editedBike.id == bike.id) {
            return this.editBike;
        } else {
            return this.readOnlyTemplate;
        }
    }

    saveBike() {
        if(this.isNewRecord) {
            this.serv.createBike(this.editedBike as Bike).subscribe(data => {
                this.statusMessage = 'Данные успешно добавлены',
                this.loadBikes();
            })
        }
    }

    cancel() {
        if(this.isNewRecord) {
            this.bikes.pop();
            this.isNewRecord = false;
        }
        this.editedBike = null;
    }

    deleteBike(bike: Bike) {
        this.serv.deleteBike(bike.id).subscribe(data => {
            this.statusMessage = 'Данные успешно удалены',
            this.loadBikes();
        }) 
    }
 }