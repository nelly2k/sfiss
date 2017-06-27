import { NgModule } from "@angular/core";
import { FormsModule } from '@angular/forms';
import { BrowserModule } from "@angular/platform-browser";
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '@angular/material';

import { APP_CONFIG, AppConfig } from './app.config';

import { AppComponent } from "./app.component";

import { ExerciseSearchComponent } from "./exercise/exercise.search.component";
import { ExerciseViewComponent } from "./exercise/exercise.view.component";
import { DashboardComponent } from "./dashboard/dashboard.component";

import { ExerciseService } from "./exercise/exercise.service";
import { AppRoutingModule } from "./app-routing.module";

@NgModule({
    imports: [BrowserModule, HttpModule, FormsModule, RouterModule, AppRoutingModule, MaterialModule],
    declarations: [AppComponent, ExerciseSearchComponent, ExerciseViewComponent, DashboardComponent],
    bootstrap: [AppComponent],
    providers: [{ provide: APP_CONFIG, useValue: AppConfig }, ExerciseService]
})
export class AppModule { }