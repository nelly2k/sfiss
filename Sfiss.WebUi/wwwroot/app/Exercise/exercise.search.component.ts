import { ExerciseService } from "./exercise.service";
import { Component, OnInit } from "@angular/core";
import { Router } from '@angular/router';


@Component({
    selector: "exercise-search",
    templateUrl:"./app/exercise/exercise.search.component.html"
})

export class ExerciseSearchComponent {

    constructor(private router: Router) {
        
    }

    gotoExercise(): void {
        this.router.navigate(["/exercise", "my-exercise"]);
    }
}