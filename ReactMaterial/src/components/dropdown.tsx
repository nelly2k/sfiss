import * as React from "react";
import {Guid} from "./utils";

export interface IDropDownItem{
    id:string;
    title:string;
    icon:string;
}

interface IDropDownProps{
    items:IDropDownItem[];
    value?:string;
    onChange?:(id:string)=>void
}

export class DropDown extends React.Component<IDropDownProps>{
    guid:string;

    constructor(props){
        super(props)
        this.guid = Guid.newGuid();
    }

    getSelectedIcon(value:string):string {
        var item =  this.props.items.find(i=>i.id == value);
        return item?item.icon:"";
    }

    getSelectedTitle(value:string):string {
        var item= this.props.items.find(i=>i.id == value);
        return item?item.title:"";
    }

    render(){
        return <div>
            <a className='dropdown-button btn-flat' href='#' data-activates={this.guid}><i className="material-icons">{this.getSelectedIcon(this.props.value)}</i> 
                {this.getSelectedTitle(this.props.value)}<i className="material-icons">arrow_drop_down</i></a>
                <ul id={this.guid} className='dropdown-content'>
                    {this.props.items.map(i=><li key={i.id}><a href="#!" onClick={()=>this.props.onChange(i.id)}><i className="material-icons">{i.icon}</i>{i.title}</a></li>)}      
                </ul>
        </div>
    }
}