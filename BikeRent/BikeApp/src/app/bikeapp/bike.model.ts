import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BikeComponent } from "./bike.component";
import { BikeService } from "./bike.service";
import { BikeTypeService } from "../biketypeapp/biketype.service";

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [BikeComponent],
    providers: [BikeService, BikeTypeService],
    bootstrap: [BikeComponent]
})
export class BikeModule{}