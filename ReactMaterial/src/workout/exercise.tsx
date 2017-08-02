import * as React from "react";
import {MeasureType,MeasureTypeOptions} from "./data";
import {DropDown} from "../components/dropdown"

interface IWorkoutExerciseProps {
    title : string;
    img?: string;
    measureType?:string;
    ifInOrder : boolean;
}

interface IWorkoutExerciseStats{
    measureType:string;
}

export class WorkoutExercise extends React.Component < IWorkoutExerciseProps,IWorkoutExerciseStats> {
    state : IWorkoutExerciseStats = {} as IWorkoutExerciseStats;

    constructor(props){
        super(props);
        this.setMeasureType = this.setMeasureType.bind(this);
    }

    componentDidMount(){
        var measureType = MeasureType[this.props.measureType?this.props.measureType:MeasureType.Rounds].toLowerCase();
        this.setState({ measureType:measureType})
    }

    setMeasureType(measureType:string){
        this.setState({measureType: measureType})
    }
    render() {
        return <div>
            <div className="row">
                <div className="col s1">
                    {this.props.img && <img src={this.props.img} className="responsive-img"/>
}
                </div>

                <div className="col s10">
                    <div className="row">
                        <div className="col s12 valign-wrapper">
                            <div className="inline">
                                <h5 >{this.props.title}</h5>
                            </div>
                        </div>
                    </div>
                    <div className="row">
                        <div className="col s12 valign-wrapper">
                            {this.props.ifInOrder && <div className="input-field inline">
                                <input type="number" id="sets"/>
                                <label htmlFor="sets">Sets</label>
                            </div>
                            }
                            <div className="inline">
                            <DropDown
                                value={this.state.measureType}
                                onChange={this.setMeasureType}
                                items={MeasureTypeOptions}/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    }
}