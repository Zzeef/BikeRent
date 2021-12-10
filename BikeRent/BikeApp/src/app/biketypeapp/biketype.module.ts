import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BikeTypeComponent } from "./biketype.component";
import { BikeTypeService } from "./biketype.service";

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [BikeTypeComponent],
    providers: [BikeTypeService],
    bootstrap: [BikeTypeComponent]
})
export class AppModule{}