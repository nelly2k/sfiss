import * as React from "react";
import {IExerciseFilter} from "./filter";

interface IExerciseSearchProps {
    data:IExerciseSearchItem[];
}
export class ExerciseSearch extends React.Component<IExerciseSearchProps>{

    render(){
        return <div className="row">
                {this.props.data.map(item=><ExerciseSearchCard key={item.Id} {...item} />)}
            </div>
    }
}

export const ExerciseSearchCard =(props:IExerciseSearchItem)=>
    <div className="col s12 m6 l3 ">
        <div className="card waves-effect waves-orange" style={{"display":"block"}}>
            <div className="card-image"> 
                <img src={"data:image/png;base64," + props.Img}/>
                <span className="card-title black-text">{props.Title}</span>
            </div>
        </div>
    </div>


export interface IExerciseSearchItem{
    Id:number,
    Title:string;
    Complexity:string;
    ExerciseType:string;
    Img:ByteString;
}

