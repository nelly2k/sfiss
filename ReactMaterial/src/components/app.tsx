import * as React from "react";
import {ExercisesPage} from "../exercise/page";
import {WorkoutsPage} from "../workout/workoutsPage";
import {DashboardPage} from "../dashboard/dashboardpage";

import {Route, Switch, Link} from "react-router-dom";
import {Navbar} from "./navbar"

export const App = () => <div>
    <Navbar/>
<div className="container">
    <Switch>
        <Route exact path="/" component={WorkoutsPage}/>
        <Route path="/exercises" component={ExercisesPage}/>
        <Route path="/workouts" component={WorkoutsPage}/>
    </Switch>
    </div>
</div>