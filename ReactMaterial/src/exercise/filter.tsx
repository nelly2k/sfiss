import * as React from "react";
import {ExerciseTypes, EquipmentType} from "./exerciseType";
import {MuscleSelector} from "./muscle";
import {MultiSelect} from "../components/MultiSelect"

export interface IExerciseFilter{
    title:string;
    types:string[];
    equipment:string[];
    muscles:string[];
}

export interface IExerciseFilterProps{
    onChange?: (filter:IExerciseFilter)=>void,
}

export class ExerciseFilter extends React.Component<IExerciseFilterProps, IExerciseFilter> {
    filter:IExerciseFilter = {} as IExerciseFilter;
    state:IExerciseFilter={
        muscles:[],
        title:"",
        types:[],
        equipment:[]
    } as IExerciseFilter;

    constructor(props){
        super(props);
        this.handleClear = this.handleClear.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    handleClear(){
        this.filter = {muscles:[], types:[], equipment:[], title:""} as IExerciseFilter;
        this.setState(this.filter);
        this.props.onChange(this.filter);
    }

    handleChange(setFilter:(filter:IExerciseFilter)=>void){
        setFilter(this.filter);
        this.props.onChange(this.filter);
        this.setState(this.filter);
    }

    render() {
        return <div>
            <div className="row">
                <div className="col s4">
                    <h5>Filter</h5>
                </div>
                <div className="col s8">
                    <button className="btn-flat right" style={{"marginTop":"10px"}} onClick={this.handleClear}>Clear filter</button>
                </div>
            </div>
            <div className="row">
                <div className="input-field col s12">
                    <input
                        id="exercise_title"
                        onChange={event=>this.handleChange(f=>f.title = event.target.value)}
                        value={this.state.title}
                        type="text"/>
                        <label htmlFor="exercise_title">Title</label>
                </div>
            </div>
            <div className="row">
                <div className="col s12">
                    <MultiSelect label="Type" 
                        onChange={types=>this.handleChange(f=>f.types = types)} 
                        selectedIds={this.state.types} 
                        data={ExerciseTypes}/>
                </div>
            </div>
            <div className="row">
                <div className="col s12">
                     <MultiSelect label="Equipment" 
                         onChange={eqs=>this.handleChange(f=>f.equipment = eqs)} 
                        selectedIds={this.state.equipment} 
                        data={EquipmentType}/>
                </div>
            </div>
            <div className="row">
                <div className="col s12">
                    <MuscleSelector 
                        onChange={msc=>this.handleChange(f=>f.muscles = msc)} 
                        selectedTags={this.state.muscles}/>
                </div>
            </div>

        </div>
    }
}