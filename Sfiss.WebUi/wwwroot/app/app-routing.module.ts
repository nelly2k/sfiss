import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ExerciseSearchComponent } from "./exercise/exercise.search.component";
import { ExerciseViewComponent } from "./exercise/exercise.view.component";
import { DashboardComponent } from "./dashboard/dashboard.component";

const routes: Routes = [
    { path: "", redirectTo: "/dashboard", pathMatch: "full" },
    { path: "dashboard", component: DashboardComponent },
    { path: "exercises", component: ExerciseSearchComponent },
    { path: "exercise/:tag", component: ExerciseViewComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {}