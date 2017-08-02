import * as React from "react";
import {WorkoutSection, SectionType} from "./section";

export class BuildWorkout extends React.Component {

    
    render() {
        return <div>
            <div className="row">
                <div className="col s12">
                    <div className="right">
                        <a className="waves-effect waves-orange btn-flat">
                            <i className="material-icons left">remove_red_eye</i>preview</a>
                        <a className="waves-effect waves-orange btn-flat">
                            <i className="material-icons left">share</i>Share</a>
                        <a className="waves-effect waves-orange btn-flat">
                            <i className="material-icons left">attach_money</i>Sell</a>
                        <a className="waves-effect waves-orange btn-flat">
                            <i className="material-icons left">delete</i>delete</a>
                    </div>

                </div>
            </div>
            <div className="row">
                <div className="input-field col s12">
                    <input id="workout_title" type="text"/>
                    <label htmlFor="workout_title">Workout Title</label>
                </div>
            </div>
            <ul className="collapsible" data-collapsible="expandable">
                <WorkoutSection title="Section 1" time="10 min" sectionType={SectionType.Circuit}/>
                <WorkoutSection title="Section 2" time="15 min" active/>
            </ul>
        </div>
    }
}

