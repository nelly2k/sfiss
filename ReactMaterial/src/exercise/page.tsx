import * as React from "react";
import {ExerciseFilter, IExerciseFilter} from "./filter";
import {ExerciseSearch,IExerciseSearchItem} from "./search";
import axios  from "axios";

export const ExercisesPage=()=>
    <ExerciseSearchPage/>

class ExerciseSearchPage extends React.Component{
    state:any = {data:[]}
    

    constructor(props){
        super(props);
        this.handleFilterChange = this.handleFilterChange.bind(this);
    }

    componentDidMount(){
        this.search({title:""} as IExerciseFilter);
    }

    search(filter:IExerciseFilter){
     axios.post("http://localhost:8406/api/exercise", {
         title:filter.title,
         "pageSize":1,
         "pageNumber":1
     }) .then(response=>{
         
         this.setState({
           data:response.data.Data
       })
     }).catch(console.log)  
    }

    handleFilterChange(filter:IExerciseFilter){
        this.search(filter);
    }

    
    render(){
        return <div className="row">
        <div className="col s12 m8 l9">
            <ExerciseSearch data={this.state.data} />
        </div>
        <div className="col l3 hide-on-medium-and-down">
            <ExerciseFilter onChange={this.handleFilterChange}/>
        </div>
    </div>
    }
}