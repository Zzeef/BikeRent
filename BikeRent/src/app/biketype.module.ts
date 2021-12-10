import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { BikeTypeComponent } from './biketype.component';
import { BikeTypeService } from './biketype.service';

@NgModule({
    imports:      [ BrowserModule, FormsModule ],
    declarations: [ BikeTypeComponent ],
    bootstrap:    [ BikeTypeComponent ],
    providers:    [ BikeTypeService   ]
})
export class BikeTypeModule {}