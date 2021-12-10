import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { AppModule } from './app/biketypeapp/biketype.module';
import { BikeModule } from './app/bikeapp/bike.model';

enableProdMode();
const platform = platformBrowserDynamic();
platform.bootstrapModule(AppModule);
platform.bootstrapModule(BikeModule);
